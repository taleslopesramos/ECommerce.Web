// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.currency')
        .maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
    $('.number').maskMoney({ prefix: '', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
});

function currencyToFloat(currency) {
    currency = currency.replace(/(R\$ )/g, "");
    currency = currency.replace(/\./g, "");
    currency = currency.replace(/\,/g, ".");
    currency = parseFloat(currency);

    if (currency == NaN) 
        return 0;
    
    return currency
}