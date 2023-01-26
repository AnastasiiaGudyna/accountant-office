export interface Catalog {
    id: string;
    catalogName: string;
    catalogValues: Array<CatalogValue>;
}

export interface CatalogValue {
    id?: string;
    value?: string;
    new: boolean;
}