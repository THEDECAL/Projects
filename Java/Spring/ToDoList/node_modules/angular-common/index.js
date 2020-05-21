import { Injectable, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

var FsArray = (function () {
    function FsArray() {
    }
    /**
     * @param {?} array
     * @param {?} name
     * @param {?} value
     * @return {?}
     */
    FsArray.prototype.nameValue = function (array, name, value) {
        var /** @type {?} */ list = [];
        if (name || value) {
            var /** @type {?} */ nameFn_1 = typeof name === 'function' ? name : function (item) { return item[name]; };
            var /** @type {?} */ valueFn_1 = typeof value === 'function' ? value : function (item) { return item[value]; };
            array.forEach(function (item) {
                list.push({ name: nameFn_1(item), value: valueFn_1(item) });
            });
        }
        else {
            array.forEach(function (name, value) {
                list.push({ name: name, value: value });
            });
        }
        return list;
    };
    /**
     * @param {?} array
     * @param {?} query
     * @return {?}
     */
    FsArray.prototype.remove = function (array, query) {
        var /** @type {?} */ idx = this.indexOf(array, query);
        if (idx >= 0) {
            return array.splice(idx, 1);
        }
        return idx;
    };
    /**
     * @param {?} array
     * @param {?} query
     * @return {?}
     */
    FsArray.prototype.indexOf = function (array, query) {
        var _this = this;
        if (typeof query !== 'function') {
            var /** @type {?} */ queryObj_1 = query;
            query = function (item) {
                return _this.compare(queryObj_1, item);
            };
        }
        for (var /** @type {?} */ i = 0, /** @type {?} */ len = array.length; i < len; i++) {
            if (query(array[i])) {
                return i;
            }
        }
        return -1;
    };
    /**
     * @param {?} query
     * @param {?} item
     * @return {?}
     */
    FsArray.prototype.compare = function (query, item) {
        var /** @type {?} */ value = true;
        for (var /** @type {?} */ key in query) {
            value = value && item[key] == query[key];
        }
        return value;
    };
    /**
     * @param {?} array
     * @param {?} query
     * @return {?}
     */
    FsArray.prototype.filter = function (array, query) {
        var _this = this;
        if (typeof query !== 'function') {
            var /** @type {?} */ queryObj_2 = query;
            query = function (item) {
                return _this.compare(queryObj_2, item);
            };
        }
        var /** @type {?} */ isarray = Array.isArray(array);
        var /** @type {?} */ list = isarray ? [] : {};
        if (isarray)
            array.forEach(function (item, idx) {
                if (query(item)) {
                    list.push(item);
                }
            });
        else
            Object.keys(array).forEach(function (key) {
                if (query(array[key])) {
                    list[key] = array[key];
                }
            });
        return list;
    };
    /**
     * @param {?} array
     * @param {?} property
     * @return {?}
     */
    FsArray.prototype.index = function (array, property) {
        var /** @type {?} */ list = {};
        array.forEach(function (item, idx) {
            list[item[property]] = item;
        });
        return list;
    };
    /**
     * @param {?} array
     * @param {?} query
     * @param {?=} reverse
     * @return {?}
     */
    FsArray.prototype.sort = function (array, query, reverse) {
        if (reverse === void 0) { reverse = false; }
        if (typeof query !== 'function') {
            var /** @type {?} */ queryStr_1 = query;
            query = function (a, b) {
                if (reverse) {
                    if (a[queryStr_1] < b[queryStr_1]) {
                        return 1;
                    }
                    else if (a[queryStr_1] > b[queryStr_1]) {
                        return -1;
                    }
                }
                else {
                    if (a[queryStr_1] > b[queryStr_1]) {
                        return 1;
                    }
                    else if (a[queryStr_1] < b[queryStr_1]) {
                        return -1;
                    }
                }
                return 0;
            };
        }
        array.sort(query);
        return array;
    };
    /**
     * @param {?} array
     * @param {?} query
     * @return {?}
     */
    FsArray.prototype.rsort = function (array, query) {
        return this.sort(array, query, true);
    };
    /**
     * @param {?} array
     * @param {?} property
     * @param {?=} index
     * @return {?}
     */
    FsArray.prototype.list = function (array, property, index) {
        if (index === void 0) { index = null; }
        var /** @type {?} */ list = index ? {} : [];
        array.forEach(function (item, idx) {
            if (index) {
                list[item[index]] = item[property];
            }
            else {
                list.push(item[property]);
            }
        });
        return list;
    };
    /**
     * @param {?} objects
     * @param {?} parent_property
     * @param {?=} id_property
     * @param {?=} depth_property
     * @return {?}
     */
    FsArray.prototype.applyDepth = function (objects, parent_property, id_property, depth_property) {
        if (id_property === void 0) { id_property = 'id'; }
        if (depth_property === void 0) { depth_property = 'depth'; }
        var /** @type {?} */ keyed = {};
        objects.forEach(function (object) {
            if (!object[parent_property])
                object[depth_property] = 0;
            keyed[object[id_property]] = object;
        });
        Object.keys(keyed).forEach(function (key) {
            Object.keys(keyed).forEach(function (key) {
                if (!keyed[key][depth_property]) {
                    if (keyed[key][parent_property]) {
                        keyed[key][depth_property] = keyed[keyed[key][parent_property]][depth_property] + 1;
                    }
                }
            });
        });
        return keyed;
    };
    /**
     * @param {?} values
     * @param {?} array
     * @return {?}
     */
    FsArray.prototype.inArray = function (values, array) {
        if (!Array.isArray(values)) {
            values = [values];
        }
        for (var /** @type {?} */ i = 0, /** @type {?} */ len = values.length; i < len; i++) {
            if (array.indexOf(values[i]) >= 0) {
                return true;
            }
        }
        return false;
    };
    /**
     * @param {?} array
     * @param {?} key
     * @return {?}
     */
    FsArray.prototype.keyExists = function (array, key) {
        return array.hasOwnProperty(key);
    };
    /**
     * @param {?} array
     * @return {?}
     */
    FsArray.prototype.length = function (array) {
        return array.length;
    };
    /**
     * @param {?} unordered
     * @return {?}
     */
    FsArray.prototype.ksort = function (unordered) {
        Object.keys(unordered).sort().forEach(function (key) {
            var /** @type {?} */ value = unordered[key];
            delete unordered[key];
            unordered[key] = value;
        });
    };
    return FsArray;
}());
FsArray.decorators = [
    { type: Injectable },
];
/**
 * @nocollapse
 */
FsArray.ctorParameters = function () { return []; };

var FsArrayModule = (function () {
    function FsArrayModule() {
    }
    /**
     * @return {?}
     */
    FsArrayModule.forRoot = function () {
        return {
            ngModule: FsArrayModule,
            providers: [FsArray]
        };
    };
    return FsArrayModule;
}());
FsArrayModule.decorators = [
    { type: NgModule, args: [{
                imports: [
                    CommonModule
                ],
                declarations: [],
                exports: []
            },] },
];
/**
 * @nocollapse
 */
FsArrayModule.ctorParameters = function () { return []; };

export { FsArrayModule, FsArray };
