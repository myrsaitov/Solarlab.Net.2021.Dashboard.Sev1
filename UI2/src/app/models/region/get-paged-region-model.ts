import { RegionModel } from "./region-model";

export class GetPagedRegionModel {
    public total: number;
    public limit: number;
    public offset: number;
    public items: RegionModel[];
}
