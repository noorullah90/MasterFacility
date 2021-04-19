function fillDropDownByLookup(elementId, lookupid, parentElement) {
    let items = '<option></option>';
    let element = document.getElementById(elementId);
   
    let selectedValue = element.getAttribute('selectedValue');
    let url = document.ele;
    if (typeof lookupid !== "undefined")
        url = '/lookups/ListLookups?lookupid=' + lookupid;

    if (typeof parentElement !== "undefined") {
        let parentId = document.getElementById(parentElement).getAttribute('selectedValue');
        url = '/lookups/ListLookups?lookupid=' + parentId;
    }
    fetch(url)
        .then(response => response.json())
        .then((options) => {
            options.forEach(function (option) {
                if (option.id == selectedValue)
                    items += '<option value="' + option.id + '" selected>' + option.name + '</option>'
                else
                    items += '<option value="' + option.id + '" >' + option.name + '</option>'
            })
            element.innerHTML = items;
           
        });

    
}

function fillDropDownByURL(elementId, url) {
    let items = '<option></option>';
    let element = document.getElementById(elementId);
    let selectedValue = element.getAttribute('selectedValue');
    fetch(url)
        .then(response => response.json())
        .then((provinces) => {
            //provinces.map((province) => (
            //    console.log(province)
            //))
            provinces.forEach(function (province) {
                if (province.id == selectedValue)
                    items += '<option value="' + province.id + '" selected>' + province.name + '</option>'
                else
                    items += '<option value="' + province.id + '" >' + province.name + '</option>'
            })
            element.innerHTML = items;
            //element.selectedIndex = selectedValue;
        });
}