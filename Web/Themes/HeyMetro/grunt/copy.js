module.exports = {
    angular: {
        files: [
            {expand: true, src: "**", cwd: 'app/fonts',   dest: "angular/fonts"},
            {expand: true, src: "**", cwd: 'bower_components/bootstrap/fonts',    dest: "angular/fonts"},
            {expand: true, src: "**", cwd: 'bower_components/font-awesome/fonts', dest: "angular/fonts"},
            {expand: true, src: "**", cwd: 'app/i18n',    dest: "angular/i18n"},
            {expand: true, src: "**", cwd: 'app/images',  dest: "angular/images"},
            {expand: true, src: "**", cwd: 'app/scripts', dest: "angular/scripts"},
            {expand: true, src: "**", cwd: 'app/views',   dest: "angular/views"},
            {src: 'app/index.min.html', dest: 'angular/index.html'}
        ]
    },
    html: {
        files: [
            {expand: true, src: '**', cwd: 'app/fonts/',  dest: 'html/fonts/'},
            {expand: true, src: "**", cwd: 'bower_components/bootstrap/fonts',    dest: "html/fonts"},
            {expand: true, src: "**", cwd: 'bower_components/font-awesome/fonts', dest: "html/fonts"},
            {expand: true, src: '**', cwd: 'app/images/',   dest: 'html/images/'},
            {expand: true, src: '**', cwd: 'app/styles/',   dest: 'html/styles/'},
            {expand: true, src: '**', cwd: 'swig/scripts/', dest: 'html/scripts/'}
        ]
    }
};
