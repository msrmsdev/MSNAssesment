﻿$(function () {
    $.validator.methods.date = function (value, element) {
        return true;
    };
});