var path = require('path');

module.exports = {
    entry: './src/Feature/IFTTT/code/Community.Feature.IFTTT.Angular/ifttt.plugin.ts',
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: 'ts-loader',
                exclude: path.resolve(__dirname, "node_modules")
            }
        ]
    },
    resolve: {
        extensions: [".ts", ".js"]
    },
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'ifttt.plugin.js',
        library: "iftttPlugin",
        libraryTarget: "umd"
    },
    externals: [
        "@sitecore/ma-core",
        "@angular/core",
        "@ngx-translate/core"
    ]
};