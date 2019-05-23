const path = require('path');
const bundleOutputDir = './wwwroot/dist';
const VueLoaderPlugin = require('vue-loader/lib/plugin');


module.exports = {
    resolve: {
        extensions: ['.js', '.vue']
    },
    entry: { 'main': './ClientApp/main.js' },
    devtool: "inline-source-map",
    module: {
        rules: [
            { test: /\.vue$/, include: /ClientApp/, loader: 'vue-loader' },
            //{ test: /\.js$/, include: /ClientApp/, use: 'awesome-typescript-loader?silent=true' },
            //{ test: /\.css$/, use: isDevBuild ? ['style-loader', 'css-loader'] : ExtractTextPlugin.extract({ use: 'css-loader?minimize' }) },
            //{ test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' }
        ]
    },
    output: {
        path: path.join(__dirname, bundleOutputDir),
        filename: '[name].js',
        publicPath: 'dist/'
    },
    plugins: [
        new VueLoaderPlugin()
    ]
}