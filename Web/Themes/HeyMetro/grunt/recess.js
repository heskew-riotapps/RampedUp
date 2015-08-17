module.exports = {
	app: {
        files: {
          'app/styles/app.css': [
            'app/less/app.less'
          ]
        },
        options: {
          compile: true
        }
    },
    angular: {
        files: {
            'angular/styles/app.min.css': [
                'bower_components/animate.css/animate.css',
                'bower_components/bootstrap/dist/css/bootstrap.css',
                'bower_components/bootstrap-additions/dist/bootstrap-additions.css',
                'bower_components/angular-motion/dist/angular-motion.css',
                'bower_components/font-awesome/css/font-awesome.css',
                'bower_components/angular-loading-bar/build/loading-bar.css',
                'app/styles/*.css'
            ]
        },
        options: {
            compress: true
        }
    },
    html: {
        files: {
            'html/styles/app.min.css': [
                'bower_components/animate.css/animate.css',
                'bower_components/bootstrap/dist/css/bootstrap.css',
                'bower_components/bootstrap-additions/dist/bootstrap-additions.css',
                'bower_components/angular-motion/dist/angular-motion.css',
                'bower_components/font-awesome/css/font-awesome.css',
                'bower_components/angular-loading-bar/build/loading-bar.css',
                'app/styles/*.css'
            ]
        },
        options: {
            compress: true
        }
    }
}
