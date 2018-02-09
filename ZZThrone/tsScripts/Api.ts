interface RequestOptions {
    ignoreCache?: boolean;
    headers?: any;
    // 0 (or negative) to wait forever
    timeout?: number;
}

const DEFAULT_REQUEST_OPTIONS = {
    ignoreCache: false,
    headers: {
        Accept: 'application/json, text/javascript, text/plain',
    },
    // default max duration for a request
    timeout: 5000,
};

interface RequestResult {
    ok: boolean;
    status: number;
    statusText: string;
    data: string;
    json: <T>() => T;
    headers: string;
}

/**
 * Handle all communications with the API
 */
class Api {

    BaseUrl: string

    constructor(baseUrl: string) {
        this.BaseUrl = baseUrl
    }   

    /**
     * Get all the entries for the give model
     * @param model Name of the model (eg. Houses)
     */
    public getAll(model: string): Promise<RequestResult> {
        return this.request('get', model);
    }

    /**
     * Get one entry by id
     * @param model
     * @param id
     */
    public getOne(model: string, id: number): Promise<RequestResult> {
        return this.request('get', model + "/" + id);
    }

    /**
     * Creates an entry
     * @param model
     * @param data
     */
    public create<T>(model: string, data: T): Promise<RequestResult> {
        return this.request('post', model, {}, data);
    }

    /**
     * Update an entry by id
     * @param model
     * @param id
     * @param data
     */
    public update<T>(model: string, id: number, data: T): Promise<RequestResult> {
        return this.request('put', model + "/" + id, {}, data);
    }

    /**
     * Remove an entry by id
     * @param model
     * @param id
     */
    public delete(model: string, id: number): Promise<RequestResult> {
        return this.request('delete', model + "/" + id);
    }

    /**
     * Low level method to use the API directly
     * @param method
     * @param url Only after host part w/o trailing slash (eg. Houses/2)
     * @param queryParams
     * @param body
     * @param options
     */
    public request(method: 'get' | 'post' | 'put' | 'delete', url: string, queryParams: any = {}, body: any = null, options: RequestOptions = DEFAULT_REQUEST_OPTIONS): Promise<RequestResult> {
        const headers = options.headers || DEFAULT_REQUEST_OPTIONS.headers;

        return new Promise<RequestResult>((resolve, reject) => {
            const xhr = new XMLHttpRequest();

            xhr.open(method, this.makeUrl(url, queryParams));

            if (headers) {
                Object.keys(headers).forEach(key => xhr.setRequestHeader(key, headers[key]));
            }

            xhr.timeout = DEFAULT_REQUEST_OPTIONS.timeout;

            xhr.onload = evt => {
                resolve(this.parseResult(xhr));
            };

            xhr.onerror = evt => {
                console.error("[API]Error making request")
                resolve(this.parseError(xhr));
            };

            xhr.ontimeout = evt => {
                console.error("[API]Request timeout");
                resolve(this.parseError(xhr));
            }


            if ((method === 'post' || method === 'put') && body) {
                xhr.setRequestHeader('Content-Type', 'application/json')
                xhr.send(JSON.stringify(body))
            } else {
                xhr.send();
            }
        });
    }

    private makeParams(params: any = {}) {
        return Object.keys(params)
            .map(k => encodeURIComponent(k) + "=" + encodeURIComponent(params[k]))
            .join('&');
    }

    private makeUrl(url: string, queryParams: any = {}) {
        const queryString = this.makeParams(queryParams);
        url = this.BaseUrl + url;

        return queryString ? url + (url.indexOf('?') === -1 ? '?' : '&') + queryString : url;
    }

    private parseResult(xhr: XMLHttpRequest): RequestResult {
        return {
            ok: xhr.status >= 200 && xhr.status < 300,
            status: xhr.status,
            statusText: xhr.statusText,
            headers: xhr.getAllResponseHeaders(),
            data: xhr.responseText,
            json: <T>() => JSON.parse(xhr.responseText) as T,
        }
    }

    private parseError(xhr: XMLHttpRequest, message?: string): RequestResult {
        return {
            ok: false,
            status: xhr.status,
            statusText: xhr.statusText,
            headers: xhr.getAllResponseHeaders(),
            data: message || xhr.statusText,
            json: <T>() => JSON.parse(message || xhr.statusText) as T,
        };
    }
}