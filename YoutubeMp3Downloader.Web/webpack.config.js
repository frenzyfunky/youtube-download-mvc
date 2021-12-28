const path = require('path');

module.exports = {
    entry: {
        index: './Scripts/Index',
        search: './Scripts/Search'
    },
    mode: 'production',
    optimization: {
        minimize: true,
        //runtimeChunk: "single"
        //splitChunks: {
        //    chunks: 'all',
        //    minSize: 0,
        //    name: false
        //    //name: 'shared'
        //}
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot/js'),
        library: ['ui', '[name]'],
        libraryTarget: 'umd'
    }
};