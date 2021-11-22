export interface ICategory {
  id: number;
  name: string;
  parentCategory: ICategory;
  count: number;
}