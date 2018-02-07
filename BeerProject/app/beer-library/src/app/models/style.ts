import { Category } from './category'
export class Style {
    public id: number;
    public categoryId: number;
    public category: Category;
    public name: string;
    public shortName: string;
    public description: string;
    public ibuMin: string;
    public ibuMax: string;
    public abvMin: string;
    public abvMax: string;
    public srmMin: string;
    public srmMax: string;
    public ogMin: string;
    public fgMin: string;
    public fgMax: string;
    public createDate: string;
    public updateDate: string;
}