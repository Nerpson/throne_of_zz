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


class Api {

    BaseUrl: string

    constructor(baseUrl: string) {
        this.BaseUrl = baseUrl
    }   

    public getAll(model: string) {
        return this.request('get', model);
    }

    private request(method: 'get' | 'post', url: string, queryParams: any = {}, body: any = null, options: RequestOptions = DEFAULT_REQUEST_OPTIONS) {
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
                console.error("[API]Error making request");
            };


            // TODO POST IF
            xhr.send();


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
}