export class Keep {
  constructor(data) {
    this.id = data.id;
    this.vaultKeepId = data.vaultKeepId || null
    this.creatorId = data.creatorId;
    this.name = data.name;
    this.description = data.description;
    this.img = data.img;
    this.views = data.views;
    this.kept = data.kept;
    this.creator = data.creator
  }
}

export class Account extends Keep {
  constructor(data) {
    super(data)
    this.creator = data.creator
  }
}