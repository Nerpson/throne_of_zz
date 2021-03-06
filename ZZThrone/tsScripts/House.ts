﻿
class HouseAPI {

    private model: string = "Houses"

    constructor(private api: Api) {
    }

    public getAllHouses(): Promise<[HouseTS]> {
        return new Promise<[HouseTS]>((resolve, reject) => {

            this.api.getAll(this.model)
                .then((result: RequestResult) => {
                    resolve(result.json<[HouseTS]>())
                });
        });
    }

    public createHouse(data: any): Promise<RequestResult> {
        return this.api.create(this.model, data);
    }
}

class HouseTS {
    ID: number;
    Name: string;
    NumberOfUnits: number;

    constructor(id: number) {
        this.ID = id;
    }
}
