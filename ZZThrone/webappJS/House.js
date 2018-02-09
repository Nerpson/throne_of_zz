class HouseAPI {
    constructor(api) {
        this.api = api;
        this.model = "Houses";
    }
    getAllHouses() {
        return new Promise((resolve, reject) => {
            this.api.getAll(this.model)
                .then((result) => {
                resolve(result.json());
            });
        });
    }
}
class HouseTS {
    constructor(id) {
        this.ID = id;
    }
}
//# sourceMappingURL=House.js.map