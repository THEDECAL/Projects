/**
 * Created by niko on 20.07.16.
 */

/**
 * @param {...string} dependencies dependencies
 * @returns {Function}
 */
export function Inject(...dependencies) {
    return function (target, key, descriptor) {
        if (descriptor) {
            let fn = descriptor.value;
            fn.$inject = dependencies || [];
        } else {
            target.$inject = dependencies || [];
        }
    };
}

/**
 * @param {string} moduleName module name
 * @param {Array} [requires = []] module requires
 * @returns {Function}
 */
export function Module(moduleName, requires = []) {
    return function (target) {
        let module = null;

        try {
            module = angular.module(moduleName);
        } catch (e) {
            module = angular.module(moduleName, requires);
        }

        module.requires.push(...requires);

        return module;
    }
}

/**
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Config(moduleName = 'app') {
    return function (target, key, descriptor) {
        console.log('register config', key);
        descriptor.value.$inject = descriptor.value.$inject || [];
        Module(moduleName)(target).config(descriptor.value);
    };
}

/**
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Run(moduleName = 'app') {
    return function (target, key, descriptor) {
        console.log('register run', key);
        descriptor.value.$inject = descriptor.value.$inject || [];
        Module(moduleName)(target).run(descriptor.value);
    };
}

/**
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Service(moduleName = 'app') {
    return function (target) {
        console.log('register service', target.name);
        target.$inject = target.$inject || [];
        Module(moduleName)(target).service(target.name, target);
    };
}

/**
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Controller(moduleName = 'app') {
    return function (target) {
        console.log('register controller', target.name);
        target.$inject = target.$inject || [];
        Module(moduleName)(target).controller(target.name, target);
    };
}

/**
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Factory(moduleName = 'app') {
    return function (target, key, descriptor) {
        console.log('register factory', key);
        descriptor.value.$inject = descriptor.value.$inject || [];
        Module(moduleName)(target).factory(target.name, descriptor.value);
    };
}

/**
 * @param {string} selector
 * @param {string} [moduleName = 'app'] module name
 * @returns {Function}
 */
export function Directive(selector, moduleName = 'app') {
    return function (target, key, descriptor) {
        if (!selector) {
            throw new Error('@Directive() must contain selector property');
        }

        // TODO fix this shit
        let directiveName = selector.replace(/-([a-z])/ig, (a, l) => l.toUpperCase());
        let params = target.toString().match(/function\s+[a-z0-9_]+\((.*?)\)/i)[1];

        Module(moduleName)(target).directive(directiveName, [
            ...target.$inject,
            eval('(' + params + ') => new target(' + params + ');')
        ]);
    };
}

/**
 * @param {string} moduleName module name
 * @returns {Promise}
 */
export function bootstrap(moduleName) {
    return new Promise(resolve => {
        angular.element(document).ready(() => {
            resolve(moduleName);
        });
    });
}