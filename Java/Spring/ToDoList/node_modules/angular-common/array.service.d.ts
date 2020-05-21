export declare class FsArray {
    nameValue(array: any, name: any, value: any): Array<any>;
    remove(array: any, query: any): any;
    indexOf(array: any, query: any): number;
    compare(query: any, item: any): boolean;
    filter(array: any, query: any): Array<any>;
    index(array: any, property: any): Object;
    sort(array: any, query: any, reverse?: boolean): Array<any>;
    rsort(array: any, query: any): Array<any>;
    list(array: any, property: any, index?: any): Object;
    applyDepth(objects: any, parent_property: any, id_property?: string, depth_property?: string): {};
    inArray(values: any, array: any): boolean;
    keyExists(array: any, key: any): any;
    length(array: any): any;
    ksort(unordered: any): void;
}
