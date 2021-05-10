var option_str = document.getElementById('Category');
for (var i = 0; i < option_str.options.length; i++) {
    if (option_str.options[i].selected)
    {
        option_str.options[i].selected = true;
    }
}

