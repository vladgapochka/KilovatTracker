window.mapHelper = (function () {
    let myMap;

    return {
        initMap: function (containerId, spinnerId, accounts) {
            
            if (myMap) {
                myMap.destroy();
            }

            document.getElementById(spinnerId).style.display = 'block';

            myMap = new ymaps.Map(containerId, {
                center: [45.0448, 38.976],
                zoom: 10
            });

            accounts.forEach(acc => {
                ymaps.geocode(acc.address, { results: 1 }).then(res => {
                    const obj = res.geoObjects.get(0);
                    if (!obj) return;

                    const coords = obj.geometry.getCoordinates();
                    const placemark = new ymaps.Placemark(coords, {
                        hintContent: acc.address,
                        balloonContent: `<strong>${acc.address}</strong><br>Потребление: ${acc.consumption} кВт`
                    }, {
                        preset: 'islands#blueHomeIcon',
                        iconColor: '#0095b6',
                        cursor: 'pointer'          
                    });

                    placemark.events.add('click', () => {
                        window.location.href = `/client-card/${acc.id}`;
                    });

                    myMap.geoObjects.add(placemark);
                });
            });

            myMap.events.once('idle', () => {
                document.getElementById(spinnerId).style.display = 'none';
            });
        }
    };
})();
