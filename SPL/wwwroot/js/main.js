/* global jQuery */

var main = function () {
    var handleMenuResponsive = function () {
        function close_menu() {
            $('.main-menu,.overlay-menu, .sidebar').removeClass('active');
            $('.hamburger').removeClass('is-active').addClass('unactive');
            $('body').removeClass('overflow-hidden');
        };
        $(document).on('click', '.hamburger.unactive', function () {
            $('.main-menu,.overlay-menu, .sidebar').addClass('active');
            $('.hamburger').removeClass('unactive').addClass('is-active');
            $('body').addClass('overflow-hidden');
            return false
        });
        $(document).on('click', '.hamburger.is-active,.bg-layer,.overlay-menu', function () {
            close_menu();
            return false;
        });
        // document.getElementsByClassName('bg-layer')[0].addEventListener('click', () => {
        //     close_menu();
        // });
        // document.getElementsByClassName('overlay-menu')[0].addEventListener('click', () => {
        //     close_menu();
        // });
    };
    var selectTow = function () {
        if ($('.form-select.form-control').length) {
            $('.form-select.form-control').select2({
                allowClear: true,
                "language": {
                    "noResults": function () {
                        return "لا يوجد نتائج";
                    }
                },
            });
            placeholder: $(this).data('placeholder');
        }
    };
    var handleDropDown = function () {
        $('.menu-item-has-children > a').on('click', function (e) {
            e.preventDefault();
            $(this).parent().find('.sub-menu').slideToggle('fast');
            $(this).parent().siblings().find('.sub-menu').slideUp('fast');
        });
        $(document).on("click", function (event) {
            var $trigger = $('.menu-item-has-children');
            if ($trigger !== event.target && !$trigger.has(event.target).length) {
                $(".sub-menu").slideUp('fast');
            }
        });
    }

    var handleFormValidation = function () {
        (() => {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            const forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.from(forms).forEach(form => {
                form.addEventListener('submit', event => {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    }

                    form.classList.add('was-validated')
                }, false)
            })
        })()
    }

    var handleCountDown = function (selector) {
        if ($(selector).length == 0) return;
        let timer2 = $(selector).html()
        const interval = setInterval(function () {
            const timer = timer2.split(':');
            //by parsing integer, I avoid all extra string processing
            let minutes = parseInt(timer[0], 10);
            let seconds = parseInt(timer[1], 10);
            --seconds;
            minutes = (seconds < 0) ? --minutes : minutes;
            seconds = (seconds < 0) ? 59 : seconds;
            seconds = (seconds < 10) ? '0' + seconds : seconds;
            $(selector).html(minutes + ':' + seconds);
            if (minutes < 0) clearInterval(interval);
            //check if both minutes and seconds are 0
            if ((seconds <= 0) && (minutes <= 0)) clearInterval(interval);
            timer2 = minutes + ':' + seconds;
        }, 1000);
    }

    var handleOtpInput = function () {
        $(".otp-form *:input[type!=hidden]:first").focus();
        let otp_fields = $(".otp-form .otp-field"),
          otp_value_field = $(".otp-form .otp-value");
        otp_fields
          .on("input", function (e) {
              $(this).val(
                $(this)
                  .val()
                  .replace(/[^0-9]/g, "")
              );
              let opt_value = "";
              otp_fields.each(function () {
                  let field_value = $(this).val();
                  if (field_value !== "") opt_value += field_value;
              });
              otp_value_field.val(opt_value);
          })
          .on("keyup", function (e) {
              let key = e.keyCode || e.charCode;
              if (key === 8 || key === 46 || key === 37 || key === 40) {
                  // Backspace or Delete or Left Arrow or Down Arrow
                  $(this).prev().focus();
              } else if (key === 38 || key === 39 || $(this).val() !== "") {
                  // Right Arrow or Top Arrow or Value not empty
                  $(this).next().focus();
              }
          })
          .on("paste", function (e) {
              let paste_data = e.originalEvent.clipboardData.getData("text");
              let paste_data_splitted = paste_data.split("");
              $.each(paste_data_splitted, function (index, value) {
                  otp_fields.eq(index).val(value);
              });
          });
    }

    var colorPalette = ['#00D8B6', '#008FFB', '#FEB019', '#FF4560', '#775DD0']

    var handleUsersChart = function () {
        var optionsLine = {
            chart: {
                height: 380,
                type: 'line',
                zoom: {
                    enabled: true
                },
            },
            stroke: {
                curve: 'smooth',
                width: 2
            },
            //colors: ["#3F51B5", '#2196F3'],
            series: [{
                name: "Total Users",
                data: [1, 15, 26, 20, 33, 27, 50]
            },
                {
                    name: "Total Branches",
                    data: [3, 33, 21, 42, 19, 32, 20]
                },
                {
                    name: "Shipments Status",
                    data: [0, 39, 52, 11, 29, 43, 32]
                }
            ],
            grid: {
                show: true,
                padding: {
                    bottom: 0
                }
            },
            labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
            legend: {
                position: 'top',
                horizontalAlign: 'center',
                offsetY: 0,
            }
        }
        if (document.querySelector("#users-chart") !== null) {
            var chartLine = new ApexCharts(document.querySelector('#users-chart'), optionsLine);
            chartLine.render();
        }

    }
    var handleShipmentBranch = function () {
        var optionsBar = {
            chart: {
                type: 'bar',
                height: 380,
                width: '100%',
                stacked: false,
            },
            plotOptions: {
                bar: {
                    distributed: true,
                    borderRadius: 5,
                }
            },
            colors: colorPalette,
            series: [{
                data: [150, 350, 500, 650, 200, 120]
            }],
            xaxis: {
                categories: [
                    'Al Riyadh',
                    'Assir',
                    'Al Qassim',
                    'Jazan',
                    'Al Baha',
                    'Najran',
                ],
                labels: {
                    show: false
                },
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false
                },
            },
            yaxis: {
                axisBorder: {
                    show: true
                },
                axisTicks: {
                    show: false
                },
                labels: {
                    style: {
                        colors: '#78909c'
                    }
                }
            },
            title: {
                text: 'Items count per region',
                align: 'left',
                style: {
                    fontSize: '14px'
                }
            },
            tooltip: {
                enabled: false
            },

        }
        if (document.querySelector('#shipment_branch') !== null) {
            var chartBar = new ApexCharts(document.querySelector('#shipment_branch'), optionsBar);
            chartBar.render();
        }
    }
    var handleShipmentChart = function () {
        var optionDonut = {
            chart: {
                type: 'donut',
                width: '100%',
                height: 400,
                toolbar: {
                    show: true
                }
            },
            dataLabels: {
                enabled: false,
            },
            plotOptions: {
                pie: {
                    customScale: 0.8,
                    donut: {
                        size: '75%',
                    },
                    offsetY: 20,
                },
                stroke: {
                    colors: undefined
                }
            },
            colors: colorPalette,
            title: {
                text: 'Percentage for every event %',
                style: {
                    fontSize: '14px'
                }
            },
            series: [25, 25, 25, 25],
            labels: ['Under Processing', 'Delivered', 'Returned', 'Under distribution'],
            legend: {
                position: 'right',
                offsetY: 80
            },
        }
        if (document.querySelector('#shipment_location') !== null) {
            var chartDonut = new ApexCharts(document.querySelector('#shipment_location'), optionDonut);
            chartDonut.render();
        }
    }



    var handleMapSection = function () {
        if ($('#map-canvas').length) {

            function initMap() {


                var map,
                  info = new google.maps.InfoWindow({content: ''}),
                  bounds = new google.maps.LatLngBounds(),
                  markers = [],
                  coffeeShops = [],
                  offices = [],
                  newState = false,
                  icon = new google.maps.MarkerImage('https://mapicons.mapsmarker.com/wp-content/uploads/mapicons/shape-default/color-8c4eb8/shapecolor-color/shadow-1/border-dark/symbolstyle-white/symbolshadowstyle-dark/gradient-no/bar.png'),
                  mapConfig = {
                      zoom: 10,
                      center: new google.maps.LatLng(31.9539, 35.9106),
                      panControl: false,
                      mapTypeControl: false,
                  };

                map = new google.maps.Map(document.getElementById('map-canvas'), mapConfig);

                // Change map type at zoom level
                google.maps.event.addListener(map, 'zoom_changed', function () {
                    if (map.getZoom() >= 18) {
                        map.setMapTypeId(google.maps.MapTypeId.SATELLITE);
                    } else {
                        map.setMapTypeId(google.maps.MapTypeId.ROADMAP);
                    }
                });

                var input = /** @type {HTMLInputElement} */(
                  document.getElementById('pac-input'));
                map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

                var searchBox = new google.maps.places.SearchBox((input));

                google.maps.event.addListener(map, 'bounds_changed', function () {
                    var bounds = map.getBounds();
                    searchBox.setBounds(bounds);
                });
            };


            google.maps.event.addDomListener(window, 'load', initMap);
        }

    }


    return {
        init: function () {
            handleMenuResponsive();
            selectTow();
            handleDropDown();
            handleFormValidation();
            handleCountDown('.countdown');
            handleCountDown('.resend');
            handleOtpInput();
            handleUsersChart();
            handleShipmentChart();
            handleShipmentBranch();
            handleMapSection();
        }
    };
}();

$(document).ready(function () {
    main.init();
    if ($('#dataTable').length) {
        dataTable = $('#dataTable').DataTable({
            responsive: true,
            bInfo: false,
            info: false,
            lengthChange: false,
            pageLength: 15,
            aoColumnDefs: [
                {
                    bSortable: false,
                    aTargets: [3, 5, 7, 9, 10],
                },
                {
                    targets: '_all',
                    className: 'text-center'
                }
            ],
            language: {
                paginate: {
                    next: '<svg width="8" height="12" viewBox="0 0 8 12" fill="none" xmlns="http://www.w3.org/2000/svg">\n' +
                      '<path fill-rule="evenodd" clip-rule="evenodd" d="M6.99498 4.99507C7.18246 5.1826 7.28777 5.4369 7.28777 5.70207C7.28777 5.96723 7.18246 6.22154 6.99498 6.40907L2.40198 11.0021C2.21569 11.1846 1.96488 11.2863 1.70406 11.285C1.44323 11.2837 1.19346 11.1795 1.00902 10.995C0.824583 10.8106 0.720385 10.5608 0.719068 10.3C0.71775 10.0392 0.81942 9.78836 1.00198 9.60207L4.90198 5.70207L1.00198 1.80207C0.81942 1.61578 0.71775 1.36497 0.719068 1.10414C0.720385 0.843312 0.824583 0.593541 1.00902 0.409105C1.19346 0.224668 1.44323 0.120471 1.70406 0.119153C1.96488 0.117836 2.21569 0.219506 2.40198 0.402069L6.99498 4.99507Z" fill="#42526E"/>\n' +
                      '</svg>\n',
                    previous: '<svg width="8" height="12" viewBox="0 0 8 12" fill="none" xmlns="http://www.w3.org/2000/svg">\n' +
                      '<path fill-rule="evenodd" clip-rule="evenodd" d="M1.00494 4.99505L5.59794 0.402052C5.68953 0.308597 5.79873 0.234225 5.91924 0.183236C6.03975 0.132248 6.16917 0.105654 6.30002 0.104993C6.43086 0.104332 6.56055 0.129617 6.68156 0.179386C6.80258 0.229155 6.91253 0.30242 7.00505 0.394945C7.09758 0.48747 7.17084 0.597419 7.22061 0.718435C7.27038 0.839451 7.29566 0.969132 7.295 1.09998C7.29434 1.23083 7.26775 1.36025 7.21676 1.48076C7.16577 1.60126 7.0914 1.71047 6.99794 1.80205L3.09794 5.70205L6.99794 9.60205C7.18051 9.78834 7.28218 10.0392 7.28086 10.3C7.27954 10.5608 7.17535 10.8106 6.99091 10.995C6.80647 11.1795 6.5567 11.2837 6.29587 11.285C6.03504 11.2863 5.78423 11.1846 5.59794 11.0021L1.00494 6.41005C0.817474 6.22252 0.712158 5.96822 0.712158 5.70305C0.712158 5.43789 0.817474 5.18358 1.00494 4.99605V4.99505Z" fill="#42526E"/>\n' +
                      '</svg>\n'
                },
                searchPlaceholder: "Search On Records",
                search: ""
            }
        });
    }
    if ($('#dataTable2').length) {
        dataTable2 = $('#dataTable2').DataTable({
            responsive: true,
            bInfo: false,
            info: false,
            lengthChange: false,
            pageLength: 15,
            aoColumnDefs: [
                {
                    targets: '_all',
                    className: 'text-center'
                }
            ],
            language: {
                paginate: {
                    next: '<svg width="8" height="12" viewBox="0 0 8 12" fill="none" xmlns="http://www.w3.org/2000/svg">\n' +
                      '<path fill-rule="evenodd" clip-rule="evenodd" d="M6.99498 4.99507C7.18246 5.1826 7.28777 5.4369 7.28777 5.70207C7.28777 5.96723 7.18246 6.22154 6.99498 6.40907L2.40198 11.0021C2.21569 11.1846 1.96488 11.2863 1.70406 11.285C1.44323 11.2837 1.19346 11.1795 1.00902 10.995C0.824583 10.8106 0.720385 10.5608 0.719068 10.3C0.71775 10.0392 0.81942 9.78836 1.00198 9.60207L4.90198 5.70207L1.00198 1.80207C0.81942 1.61578 0.71775 1.36497 0.719068 1.10414C0.720385 0.843312 0.824583 0.593541 1.00902 0.409105C1.19346 0.224668 1.44323 0.120471 1.70406 0.119153C1.96488 0.117836 2.21569 0.219506 2.40198 0.402069L6.99498 4.99507Z" fill="#42526E"/>\n' +
                      '</svg>\n',
                    previous: '<svg width="8" height="12" viewBox="0 0 8 12" fill="none" xmlns="http://www.w3.org/2000/svg">\n' +
                      '<path fill-rule="evenodd" clip-rule="evenodd" d="M1.00494 4.99505L5.59794 0.402052C5.68953 0.308597 5.79873 0.234225 5.91924 0.183236C6.03975 0.132248 6.16917 0.105654 6.30002 0.104993C6.43086 0.104332 6.56055 0.129617 6.68156 0.179386C6.80258 0.229155 6.91253 0.30242 7.00505 0.394945C7.09758 0.48747 7.17084 0.597419 7.22061 0.718435C7.27038 0.839451 7.29566 0.969132 7.295 1.09998C7.29434 1.23083 7.26775 1.36025 7.21676 1.48076C7.16577 1.60126 7.0914 1.71047 6.99794 1.80205L3.09794 5.70205L6.99794 9.60205C7.18051 9.78834 7.28218 10.0392 7.28086 10.3C7.27954 10.5608 7.17535 10.8106 6.99091 10.995C6.80647 11.1795 6.5567 11.2837 6.29587 11.285C6.03504 11.2863 5.78423 11.1846 5.59794 11.0021L1.00494 6.41005C0.817474 6.22252 0.712158 5.96822 0.712158 5.70305C0.712158 5.43789 0.817474 5.18358 1.00494 4.99605V4.99505Z" fill="#42526E"/>\n' +
                      '</svg>\n'
                },
                searchPlaceholder: "Search On Records",
                search: ""
            }
        });
    }

});
