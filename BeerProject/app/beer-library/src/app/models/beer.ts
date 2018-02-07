import { Glass } from './glass';
import { Srm } from './srm';
import { Style } from './style'

export class Beer {
    public id: string;
    public name: string;
    public nameDisplay: string;
    public description: string;
    public abv: string;
    public glasswareId: number;
    public srmId: number;
    public styleId: number;
    public isOrganic: string;
    public status: string;
    public statusDisplay: string;
    public createDate: string;
    public updateDate: string;
    public glass: Glass;
    public srm: Srm;
    public style: Style;
    public showDetail: boolean; 
}