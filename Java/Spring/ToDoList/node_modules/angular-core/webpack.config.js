/**
 * Created by niko on 08.07.16.
 */

const NODE_ENV = process.env.NODE_ENV || 'development';

const webpack = require('webpack');
const rimraf = require('rimraf');
const path = require('path');

const UglifyJsPlugin = webpack.optimize.UglifyJsPlugin;

var paths = {
    context: path.join(__dirname, 'sources'),
    dist: path.join(__dirname, 'dist')
};

var webpackConfig = {
    context: paths.context,
    entry: {
        index: './main'
    },
    output: {
        path: paths.dist,
        filename: '[name].bundle.js'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                exclude: /(bower_components|node_modules)/,
                loader: 'babel'
            }
        ]
    },
    plugins: [
        {
            apply: (compiler) => (rimraf.sync(compiler.options.output.path))
        }
    ]
};

if (NODE_ENV === 'development') {
    webpackConfig.devtool = 'cheap-inline-module-source-map';
    webpackConfig.watch = true;
}

if (NODE_ENV === 'production') {
    webpackConfig.plugins.push(new UglifyJsPlugin({
        compress: {
            warnings: false,
            drop_console: true
        }
    }));
}

module.exports = webpackConfig;