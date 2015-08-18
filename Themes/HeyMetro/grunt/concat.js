module.exports = {
	angular:{
    src:[
      'bower_components/jquery/dist/jquery.min.js',

      'bower_components/angular/angular.js',
      'bower_components/angular-animate/angular-animate.js',
      'bower_components/angular-cookies/angular-cookies.js',
      'bower_components/angular-resource/angular-resource.js',
      'bower_components/angular-sanitize/angular-sanitize.js',
      'bower_components/angular-touch/angular-touch.js',

      'bower_components/angular-ui-router/release/angular-ui-router.js', 
      'bower_components/ngstorage/ngStorage.js',
      'bower_components/angular-ui-utils/ui-utils.js',

      'bower_components/angular-strap/dist/angular-strap.js',
      'bower_components/angular-strap/dist/angular-strap.tpl.js',
      'bower_components/oclazyload/dist/ocLazyLoad.js',

      'bower_components/angular-translate/angular-translate.js',
      'bower_components/angular-translate-loader-static-files/angular-translate-loader-static-files.js',
      'bower_components/angular-translate-storage-cookie/angular-translate-storage-cookie.js',
      'bower_components/angular-translate-storage-local/angular-translate-storage-local.js',
     
      'bower_components/angular-loading-bar/build/loading-bar.js',
      
      'app/scripts/*.js',
      'app/scripts/directives/*.js',
      'app/scripts/services/*.js',
      'app/scripts/filters/*.js'
    ],
    dest:'angular/scripts/app.src.js'
  },
  html:{
    src:[
      'bower_components/jquery/dist/jquery.min.js',
      'bower_components/bootstrap/dist/js/bootstrap.js',
      'html/scripts/*.js'
    ],
    dest:'html/scripts/app.src.js'
  }
}
