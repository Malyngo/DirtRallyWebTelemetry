/*global module */
module.exports = function (grunt) {
    'use strict';

    var config = {
        app: 'app',
        dist: 'dist',
        test: 'tests',
        bowercomponents: 'bower_components',
        temp: '.tmp'
    };

    grunt.initConfig({
        // read in the project settings from the package.json file into the pkg property
        pkg: grunt.file.readJSON('package.json'),

        bowercopy: {
            options: {
                // Task-specific options go here
            },
            jquery: {
                options: {
                    destPrefix: config.app + '/libs/js',
                    srcPrefix: config.bowercomponents + '/jquery/dist'
                },
                files: {
                    'jquery.js': 'jquery.js'
                }
            },
            signalr: {
                options: {
                    destPrefix: config.app + '/libs/js',
                    srcPrefix: config.bowercomponents + '/signalr'
                },
                files: {
                    'jquery.signalR.js': 'jquery.signalR.js'
                }
            },
            d3: {
                options: {
                    destPrefix: config.app + '/libs/js',
                    srcPrefix: config.bowercomponents + '/d3'
                },
                files: {
                    'd3.js': 'd3.js'
                }
            }


        },

        copy: {
            requirejs: {
                expand: true,
                dot: true,
                cwd: 'node_modules/requirejs',
                dest: config.app + '/libs/',
                src: 'require.js'
            }
        },
        requirejs: {
            compile: {
                options: {
                    baseUrl: config.app + "/js",
                    mainConfigFile: config.app + "/js/App.js",
                    name: "controllers/Replay",
                    out: config.dist + "/js/controllers/Replay.js"
                }
            }
        },
        clean: {
            dist: 'dist',
            docs: 'docs',
            libs: config.app + '/libs'
        }


    });

    // Add all plugins that your project needs here
    grunt.loadNpmTasks('grunt-bowercopy');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-copy');

    // this would be run by typing "grunt test" on the command line
    // the array should contains the names of the tasks to run
    grunt.registerTask('test', []);

    // define the default task that can be run just by typing "grunt" on the command line
    // the array should contains the names of the tasks to run
    grunt.registerTask('default', []);

    grunt.registerTask('build', [
        'clean',
        'copy',
        'bowercopy'
    ]);
};