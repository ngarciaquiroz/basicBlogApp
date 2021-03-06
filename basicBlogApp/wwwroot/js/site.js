﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Initialize Editor  
    $('.textarea-editor').summernote({
        height: 300, // set editor height  
        minHeight: null, // set minimum height of editor  
        maxHeight: null, // set maximum height of editor  
        focus: true // set focus to editable area after initializing summernote  
    });
});  