/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    // place code for your default task here
});

var paths = {};
paths.webroot = "wwwroot/";
paths.npmSrc = "./node_modules/";
paths.npmLibs = paths.webroot + "lib/";


gulp.task("copy-deps:syncfusion", function () {
    return gulp.src(paths.npmSrc + '/syncfusion-javascript/**/*.*', { base: paths.npmSrc + '/syncfusion/' })
        .pipe(gulp.dest(paths.npmLibs + '/syncfusion/'));
});

gulp.task("copy-deps:bootstrap", function () {
    return gulp.src(paths.npmSrc + '/bootstrap/dist/**/*.*', { base: paths.npmSrc + '/bootstrap/' })
        .pipe(gulp.dest(paths.npmLibs + '/bootstrap/'));

});

gulp.task("copy-deps:jquery", function () {
    return gulp.src(paths.npmSrc + '/jquery/dist/**/*.*', { base: paths.npmSrc + '/jquery/dist/' })
        .pipe(gulp.dest(paths.npmLibs + '/jquery/'));
});

gulp.task("copy-deps:jsrender", function () {
    return gulp.src(paths.npmSrc + '/jsrender/**/*.*', { base: paths.npmSrc + '/jsrender/' })
        .pipe(gulp.dest(paths.npmLibs + '/jsrender/'));
});


gulp.task("copy-deps", ["copy-deps:syncfusion", 'copy-deps:jquery', 'copy-deps:bootstrap', 'jsrender']);