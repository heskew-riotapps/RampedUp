module.exports = function(grunt) {
	var gtx = require('gruntfile-gtx').wrap(grunt);

    gtx.loadAuto();

    var gruntConfig = require('./grunt');
    gruntConfig.package = require('./package.json');

    gtx.config(gruntConfig);

    gtx.alias('build:angular', ['recess:app', 'clean:angular', 'copy:angular', 'recess:angular', 'concat:angular', 'uglify:angular']);
    gtx.alias('build:html', ['clean:html', 'copy:html', 'recess:html', 'swig:html', 'concat:html', 'uglify:html']);

    gtx.alias('release', ['bower-install-simple', 'changelog:release', 'bump-commit']);
    gtx.alias('release-patch', ['bump-only:patch', 'release']);
    gtx.alias('release-minor', ['bump-only:minor', 'release']);
    gtx.alias('release-major', ['bump-only:major', 'release']);
    gtx.alias('prerelease', ['bump-only:prerelease', 'release']);

    gtx.finalise();
}
