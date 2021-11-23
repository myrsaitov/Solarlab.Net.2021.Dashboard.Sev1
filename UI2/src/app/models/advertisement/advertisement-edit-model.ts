export interface IEditAdvertisement {
  id: number;
  title: string;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tagBodies: string[];
  status: number;
  formData:FormData;
}

export class EditAdvertisement implements IEditAdvertisement {
  id: number;
  body: string;
  price: number;
  categoryId: number;
  regionId: number;
  address: string;
  tagBodies: string[];
  title: string;
  status: number;
  formData:FormData;

  constructor(data?: Partial<IEditAdvertisement>) {
    const defaults: IEditAdvertisement = {
      id: 0,
      body: '',
      price: 0,
      categoryId: null,
      regionId: null,
      address: '',
      tagBodies: [],
      title: '',
      status: null,
      formData: null,
      ...data
    };

    this.id = defaults.id;
    this.body = defaults.body;
    this.categoryId = defaults.categoryId;
    this.regionId = defaults.regionId;
    this.address = defaults.address;
    this.tagBodies = defaults.tagBodies;
    this.title = defaults.title;
    this.price = defaults.price;
    this.status = defaults.status;
    this.formData = defaults.formData;
  }
}