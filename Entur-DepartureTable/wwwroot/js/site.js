﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

n = new Date();
y = n.getFullYear();
m = n.getMonth() + 1;
d = n.getDate();
document.getElementById("date").innerHTML = d + "." + m + "." + y;

h = n.getHours();
min = n.getMinutes();
min = min < 10 ? '0' + min : min;
document.getElementById("time").innerHTML = h + ":" + min;