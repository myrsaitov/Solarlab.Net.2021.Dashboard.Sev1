export interface IEditAdvertisement {
  id: number;
  title: string;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tags: string[];
}

export class EditAdvertisement implements IEditAdvertisement {
  id: number;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tags: string[];
  title: string;

  constructor(data?: Partial<IEditAdvertisement>) {
    const defaults: IEditAdvertisement = {
      id: 0,
      body: '',
      price: 0,
      categoryId: null,
      regionId: null,
      address: '',
      tags: [],
      title: '',
      ...data
    };

    this.id = defaults.id;
    this.body = defaults.body;
    this.categoryId = defaults.categoryId;
    this.regionId = defaults.regionId;
    this.address = defaults.address;
    this.tags = defaults.tags;
    this.title = defaults.title;
    this.price = defaults.price;
  }
}