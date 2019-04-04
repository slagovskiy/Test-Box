'use strict';

const NODE_ENV = process.env.NODE_ENV || 'dev';
const webpack = require('webpack');

module.exports = {
    context: __dirname + '/frontend',
    entry: {
        home: './home',
        about: './about',
        common: './common'
    },
    output: {
        path: __dirname + '/public',
        filename: '[name].js',
        library: '[name]'
    },

    watch: NODE_ENV == 'dev',
    watchOptions: {
        aggregateTimeout: 100
    },

    devtool: NODE_ENV == 'dev' ? 'cheap-inline-module-source-map' : 'source-map',

    plugins: [
        new webpack.NoErrorsPlugin(),
        new webpack.DefinePlugin({
            NODE_ENV: JSON.stringify(NODE_ENV)
        }),
        new webpack.optimize.CommonsChunkPlugin({
            name: 'common',
            //minChunks: 2
            chunks: ['home', 'about']
        })
    ],

    resolve: {
        modulesDirectories: ['node_modules'],
        extensions: ['', '.js']
    },

    resolveLoader: {
        modulesDirectories: ['node_modules'],
        moduleTemplate: ['*-loader', '*'],
        extensions: ['', '.js']
    },

    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: 'babel?presets[]=es2015'
            }
        ]
    }
};

if (NODE_ENV == 'production') {
    module.exports.plugins.push(
        new webpack.optimize.UglifyJsPlugin ({
            compress: {
                warnings: false,
                drop_console: true,
                unsafe: true
            }
        })
    )
}
