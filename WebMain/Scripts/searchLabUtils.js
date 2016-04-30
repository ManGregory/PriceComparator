String.prototype.capitalizeFirstLetter = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
}

function fillLabMarkers() {
    labMarkers = {
        "synevo": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.410889, 30.634107),
                map: map,
                title: "вул. Анни Ахматової, 14-а<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.464636, 30.474069),
                map: map,
                title: "вул. Білоруська, 32<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.414163, 30.523712),
                map: map,
                title: "вул. Велика Васильківська, 136<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.510702, 30.621817),
                map: map,
                title: "вул. Вишгородська, 56/2<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.499064, 30.516209),
                map: map,
                title: "вул. Героїв Сталінграду, 8<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.383544, 30.481521),
                map: map,
                title: "пр. Голосіївський, 126<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.390430, 30.499427),
                map: map,
                title: "пр. Голосіївський, 98/2<br/>(044) 20 500 20 </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.522185, 30.611282),
                map: map,
                title: "вул. Данькевича, 16<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.510729, 30.621817),
                map: map,
                title: "вул. Закревського, 51/2<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.403200, 30.626128),
                map: map,
                title: "вул. Княжий Затон, 4<br/>(044) 20 500 20</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.467259, 30.511603),
                map: map,
                title: "вул. Костянтинівська, 20<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.482973, 30.606877),
                map: map,
                title: "вул. Курнатовського, 4-Б<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.427670, 30.374725),
                map: map,
                title: "пр. Леся Курбаса, 16-А<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.454333, 30.597728),
                map: map,
                title: "вул. Луначарського, 10<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.396846, 30.638571),
                map: map,
                title: "вул. Мішуги, 3-В<br/>(044) 20 500 20;</br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.504459, 30.491385),
                map: map,
                title: "вул. Малиновського, 9<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.428074, 30.456287),
                map: map,
                title: "вул. Мартиросяна, 1/8<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.510170, 30.432890),
                map: map,
                title: "вул. Межова, 24<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.399368, 30.651029),
                map: map,
                title: "пр. Миколи Бажана, 36-А<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб,нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.466248, 30.446497),
                map: map,
                title: "вул. Олени Теліги, 3<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.527736, 30.500467),
                map: map,
                title: "вул. Північна, 2/5<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.415420, 30.545210),
                map: map,
                title: "вул. Підвисоцького, 6<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.472735, 30.358166),
                map: map,
                title: "пр. Паладіна, 46/2<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.457799, 30.382916),
                map: map,
                title: "пр. Перемоги, 108/1<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.449576, 30.479612),
                map: map,
                title: "пр. Перемоги, 16<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.453803, 30.449493),
                map: map,
                title: "пр. Перемоги, 45<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.459155, 30.630314),
                map: map,
                title: "вул. Попудренка, 46/2-А<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.511109, 30.418211),
                map: map,
                title: "пр. Порика, 7а<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.460363, 30.345000),
                map: map,
                title: "вул. Прилужна, 4/15<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.433938, 30.603563),
                map: map,
                title: "вул. Серафимовича, 13а<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.415403, 30.391131),
                map: map,
                title: "вул. Симиренко, 2/19<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.508761, 30.599178),
                map: map,
                title: "вул. Теодора Драйзера, 24<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.511151, 30.505211),
                map: map,
                title: "вул. Тимошенко, 18<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.487648, 30.469472),
                map: map,
                title: "вул. Фрунзе, 111/2<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.418409, 30.654452),
                map: map,
                title: "Харківське шосе, 152<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.430695, 30.455142),
                map: map,
                title: "бул. Чоколівський, 19<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб, нд: 8:00 - 14:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.436551, 30.518006),
                map: map,
                title: "вул. Шота Руставелі, 40<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.477912, 30.405172),
                map: map,
                title: "вул. Щербакова, 57<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.446793, 30.626726),
                map: map,
                title: "пр. Юрія Гагаріна, 9<br/>(044) 20 500 20; </br>пн - пт: 7:00 - 18:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            })
        ],



        "dila": [


            new google.maps.Marker({
                position: new google.maps.LatLng(50.414856, 30.544515),
                map: map,
                title: "вул. Підвисоцького, 6А<br/>(044) 531-94-91<br/>0 800 606 777;</br>пн - пт: 7:00 - 20:00,<br/>сб: 8:00 - 15:00,<br/>нд: 9:00 - 13:00,"
            }),

            new google.maps.Marker({
                position: new google.maps.LatLng(50.409250, 30.640065),
                map: map,
                title: "вул. Драгоманова, 17<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 20:00,<br/>сб: 8:00 - 15:00,<br/>нд: 9:00 - 13:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.457213, 30.345394),
                map: map,
                title: "вул. Чорнобильська, 5/7<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:30 - 17:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.497372, 30.606667),
                map: map,
                title: "вул. Драйзера, 1<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.446806, 30.626737),
                map: map,
                title: "пр-т Гагаріна, 9<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.444877, 30.492613),
                map: map,
                title: "вул. Старовокзальна, 17<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:30 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.439994, 30.526101),
                map: map,
                title: "вул. Шовковична, 46/48<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.506924, 30.610381),
                map: map,
                title: "пр-т. Маяковського, 26 А<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: 9:00 - 13:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.449721, 30.512218),
                map: map,
                title: "вул. Ярославів Вал, 8<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 16:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.411727, 30.655633),
                map: map,
                title: "вул. Вербицького, 5<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:45 - 14:00,<br/>сб: 9:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.445462, 30.538987),
                map: map,
                title: "вул. Грушевського, 28/2, к. 41<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.495101, 30.518512),
                map: map,
                title: "вул. Мате Залки, 1/12<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.523543, 30.464053),
                map: map,
                title: "вул. Кондратюка, 8<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 16:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.476842, 30.631158),
                map: map,
                title: "вул. Курчатова, 18 А<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.466362, 30.624833),
                map: map,
                title: "вул. Миропільська, 15 Б<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 8:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.523974, 30.497846),
                map: map,
                title: "пр-т Оболонський, 49<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 19:00,<br/>сб: 8:00 - 14:00,<br/>нд: 9:00 - 13:00"
            }),

            new google.maps.Marker({
                position: new google.maps.LatLng(50.427080, 30.461749),
                map: map,
                title: "пр-т Повітрофлотський, 42<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 17:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"
            }),

            new google.maps.Marker({
                position: new google.maps.LatLng(50.382959, 30.479117),
                map: map,
                title: "пр-т Голосіївський, 130/57<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 17:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),

            new google.maps.Marker({
                position: new google.maps.LatLng(50.427705, 30.374767),
                map: map,
                title: "пр-т Л. Курбаса, 16 А<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 16:00,<br/>сб: 8:00 - 13:00,<br/>нд: 8:00 - 13:00"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.412458, 30.664770),
                map: map,
                title: "Харьківське шосе, 172<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 7:00 - 14:00,<br/>сб: 8:00 - 13:00,<br/>нд: вихідний"
            }),



            new google.maps.Marker({
                position: new google.maps.LatLng(50.430452, 30.608450),
                map: map,
                title: "пр. П. Тичини, 22<br/>(044) 531-94-91,<br/>0 800 606 777;</br>пн - пт: 8:00 - 13:00,<br/>сб: 8:00 - 12:00,<br/>нд: вихідний"
            })
        ],




        "dnk": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.476553, 30.439590),
                map: map,
                title: "вул. Подвойського 9<br/>(044) 453-64-79,<br/>(044) 453-64-84</br>пн - пт: 8:00 - 19:00,<br/>сб: 9:00 - 14:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.396537, 30.629175),
                map: map,
                title: "вул. Гришка 4а<br/>(044) 572-38-27,<br/>(044) 572-38-31</br>пн - пт: 7:00 - 17:00,<br/>сб: 9:00 - 12:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.498231, 30.588649),
                map: map,
                title: "просп. Маяковського 5<br/>(044) 548-26-41</br>пн - пт: 8:00 - 16:30,<br/>сб: 9:00 - 12:00,<br/>нд: вихідний"
            })
        ],



        "bioplus": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.399234, 30.647867),
                map: map,
                title: "Пр. Миколи Бажана, 30<br/>(044) 303 91 93;<br/>(044) 496 93 91</br>пн - пт: 8:00 - 20:00,<br/>сб: 8:00 - 16:00,<br/>нд: вихідний"
            })
        ],



        "uldc": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.448429, 30.465452),
                map: map,
                title: "вул. Політехнічна, 25/29<br/>(044) 492-34-84;<br/>(044) 277-33-54</br>пн - пт: 8:00 - 16:00,<br/>сб, нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.511365, 30.496200),
                map: map,
                title: "вул. Маршала Тимошенка, 14<br/>(044) 492-34-84;<br/>(044) 485-04-94</br>пн - пт: 8:00 - 16:00,<br/>сб, нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.518912, 30.451415),
                map: map,
                title: "вул. Вишгородська, 54-а<br/>(044) 492-34-84;<br/>(044) 485-04-94</br>пн - пт: 8:00 - 16:00,<br/>сб, нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.454281, 30.588712),
                map: map,
                title: "вул. Микільсько-Слобідська, 6-в<br/>(044) 492-34-84;<br/>(044) 485-04-94</br>пн - пт: 8:00 - 19:30,<br/>сб: 9:00 - 17:00,<br/>нд: вихідний"
            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.479043, 30.604300),
                map: map,
                title: "вул. Петра Запорожця, 26<br/>(044) 492-34-84;<br/>(044) 542-00-84</br>пн - пт: 8:00 - 19:00,<br/>сб: 9:00 - 15:00,<br/>нд: вихідний"
            })
        ],



        "nikolab": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.468355, 30.508707),
                map: map,
                title: "ул. Щекавицька 9А<br/>(044) 338 06 03</br>пн - пт: 7:30 - 18:00,<br/>сб, нд: 8:30 - 15:00"
            })
        ],



        "medlabtest": [
            new google.maps.Marker({
                position: new google.maps.LatLng(50.427817, 30.461889),
                map: map,
                title: "вул. Соціалістична, 5/1<br/>(044) 248-87-78,<br/>(044) 248-88-48</br>пн - пт: 8:00 - 19:00,<br/>сб: 9:00 - 17:00,<br/>нд: вихідний"

            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.436328, 30.412492),
                map: map,
                title: "просп. Комарова, 3 корп.3<br/>(044) 497-00-03</br>пн - пт: 8:00 - 16:00,<br/>сб., нд: вихідний"

            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.413544, 30.532631),
                map: map,
                title: "бул. Дружби Народів, 7<br/>(044) 529-92-70</br>пн - пт: 8:00 - 17:00,<br/>сб: 8:00 - 14:00,<br/>нд: вихідний"

            }),
            new google.maps.Marker({
                position: new google.maps.LatLng(50.413992, 30.665786),
                map: map,
                title: "Харьківське шосе, 121<br/>(044) 337-14-38</br>пн - пт: 8:00 - 16:00,<br/>сб, нд: вихідний"


            })
        ]
    }
}

function initialize() {
    var position = new google.maps.LatLng(50.510702, 30.621817);
    var mapCanvas = document.getElementById('map-canvas');
    var mapOptions = {
        center: position,
        zoom: 16,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(mapCanvas, mapOptions);
    geocoder = new google.maps.Geocoder();
    searchMarkers = new Array();
    searchCircles = new Array();
    fillLabMarkers();
};

function getSearchForm() {
    return document.getElementById("searchForm");
}

function getSearchFormLabs() {
    return document.getElementById("searchFormLabs");
}

function clearSearchMarkers() {
    for (var i = 0; i < searchMarkers.length; i++) {
        searchMarkers[i].setMap(null);
    }
}

function clearSearchCircles() {
    for (var i = 0; i < searchCircles.length; i++) {
        searchCircles[i].setMap(null);
    }
}

function clearMap() {
    clearSearchMarkers();
    clearSearchCircles();
    $("#searchResults").empty();
}

function processSearchForm(e) {
    if (e.preventDefault) e.preventDefault();
    clearMap();
    var searchForm = getSearchForm();
    var address = 'Київ, ' + searchForm.Streets.value + ', ' + searchForm.searchHome.value;
    var request = {
        'address': address,
        componentRestrictions : {
            country : 'UA'
        }
    };
    geocoder.geocode(request, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            var marker = new google.maps.Marker({
                map: map,
                title: address,
                position: new google.maps.LatLng(results[0].geometry.location.lat(), results[0].geometry.location.lng())
            });
            searchMarkers.push(marker);
            map.setCenter(marker.position);
            showClosestMarkers(marker.position.lat(), marker.position.lng(), 1000);
        } else {
            alert('Невірна адреса');
        }
    });
    return false;
}

function processLabNameChange(e) {
    if (e.preventDefault) e.preventDefault();
    clearMap();
    var labNameSelect = getSearchFormLabs().labName;
    var showAll = false;
    for (var i = 0; i < labNameSelect.options.length; i++) {
        var labName = labNameSelect.options[i].value;
        if (labName != "") {
            var markers = labMarkers[labName.toLowerCase()];
            for (var j = 0; j < markers.length; j++) {
                markers[j].setMap(labNameSelect.options[i].selected || showAll ? map : null);
            }
            if (markers.length > 0 && markers[0].map != null) {
                map.setCenter(markers[0].position);
            }
        } else {
            showAll = labNameSelect.options[i].selected;
        }
    }
    return false;
}

function getMarkers() {
    var markers = new Array();
    for (key in labMarkers) {
        for (var i = 0; i < labMarkers[key].length; i++) {
            markers.push(labMarkers[key][i]);
            labMarkers[key][i]["labName"] = key.toString().capitalizeFirstLetter();
        }
    }
    return markers;
}

function addSearchResult(marker, distance) {
    marker.setMap(map);
    map.setCenter(marker.position);

    $("#searchResults").append('<li><b>' + marker.labName + '</b> - ' + marker.title + '<br/>' + (distance/1000).toFixed(1) + ' км' + '</li>');
}

function showClosestMarkers(lat1, lon1, maximumRadius) {
    var pi = Math.PI;
    var R = 6371; //equatorial radius

    var markers = getMarkers();

    for (var i = 0; i < markers.length; i++) {
        var lat2 = markers[i].position.lat();
        var lon2 = markers[i].position.lng();

        var chLat = lat2 - lat1;
        var chLon = lon2 - lon1;

        var dLat = chLat * (pi / 180);
        var dLon = chLon * (pi / 180);

        var rLat1 = lat1 * (pi / 180);
        var rLat2 = lat2 * (pi / 180);

        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.sin(dLon / 2) * Math.sin(dLon / 2) * Math.cos(rLat1) * Math.cos(rLat2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c * 1000;

        if (d < maximumRadius) {
            addSearchResult(markers[i], d);
        } else {
            markers[i].setMap(null);
        }

        var searchCircle = new google.maps.Circle({
            strokeColor: '#B22222',
            strokeOpacity: 0.02,
            strokeWeight: 2,
            fillColor: '#9370DB',
            fillOpacity: 0.01,
            map: map,
            center: new google.maps.LatLng(lat1, lon1),
            radius: maximumRadius
        });
        searchCircles.push(searchCircle);
    }
}

google.maps.event.addDomListener(window, 'load', initialize);