export interface ICreateAdvertisement {
  title: string;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tagBodies: string[];
}

export class CreateAdvertisement implements ICreateAdvertisement {
  title: string;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tagBodies: string[];

  constructor(data?: Partial<ICreateAdvertisement>) {
    const defaults: ICreateAdvertisement = {
      title: '',
      body: '',
      price: 0,
      categoryId: null,
      regionId: 1,
      address: '',
      tagBodies: [],
      ...data
    };
    this.title = defaults.title;
    this.body = defaults.body;
    this.price = defaults.price;
    this.categoryId = defaults.categoryId;
    this.regionId = defaults.regionId;
    this.address = defaults.address;
    this.tagBodies = defaults.tagBodies;
  }
}