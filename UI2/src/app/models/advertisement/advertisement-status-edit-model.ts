export interface IEditAdvertisementStatus {
  id: number;
  status: number;
}

export class EditAdvertisementStatus implements IEditAdvertisementStatus {
  id: number;
  status: number;

  constructor(data?: Partial<IEditAdvertisementStatus>) {
    const defaults: IEditAdvertisementStatus = {
      id: 0,
      status: null,
      ...data
    };

    this.id = defaults.id;
    this.status = defaults.status;
  }
}