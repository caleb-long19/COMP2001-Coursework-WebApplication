<?php
include_once 'header.php';
?>

    <link rel="stylesheet" href="resources/styles.css">


    <main class="container">
        <div class="starter-template text-center py-5 px-3">
            <h1>Plymouth's Libraries: Library Data</h1>
            <p class="lead">This is the Data Set Page, this contains information of Plymouth Libraries (2019) and are being displayed in a readable format!
            If you wish to see the data in a larger format, please visit "Extended Library Data" Page </p>
        </div>
    </main><!-- /.container -->

    <style>
        #libraries td, #customers th {
            border: 1px solid #ddd;
            padding: 8px;
        }

        #libraries tr:nth-child(even){background-color: #f2f2f2;}

        #libraries tr:hover {background-color: #ddd;}

        #libraries th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: #4CAF50;
            color: white;
        }
    </style>

    <div class="container-fluid col-8">
        <div class="row">
            <div class="col-12">
                <table class="table">
                    <thead>
                    <tr class="table-danger">
                        <th scope="col">Library Name</th>
                        <th scope="col">Address Line</th>
                        <th scope="col">Post Code</th>
                        <th scope="col">Latitude</th>
                        <th scope="col">Longitude</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php
                    if (($csvlibraryfile = fopen("../public/resources/tableData.csv", "r")) !== FALSE) {
                        while (($csvlibrarydata = fgetcsv($csvlibraryfile, 1000, ",")) !== FALSE) {
                            $error='';
                            $colcount = count($csvlibrarydata);
                            echo '<tr>';
                            switch($error) {
                                default:
                                    echo '<td>'.$csvlibrarydata[0].'</td>';
                                    echo '<td>'.$csvlibrarydata[1].'</td>';
                                    echo '<td>'.$csvlibrarydata[4].'</td>';
                                    echo '<td>'.$csvlibrarydata[5].'</td>';
                                    echo '<td>'.$csvlibrarydata[6].'</td>';
                            }
                            echo '</tr>';
                        }
                        fclose($csvlibraryfile);
                    }
                    ?>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
<br>
    <div class="container-fluid col-6">
        <div class="row">
            <div class="col-12">
                <html>
                <div id='map' style='width: 900px; height: 400px;'></div>
                <script>
                    mapboxgl.accessToken = 'pk.eyJ1IjoiY3dpc3B5YyIsImEiOiJja2tjN3N2MDIwY2JqMm9xcnR0M21wczNuIn0.OfEI8q3Zw8R5GzpPYHnJpg';
                    var map = new mapboxgl.Map({
                        container: 'map',
                        style: 'mapbox://styles/mapbox/streets-v11',
                        center: [-4.143841, 50.376289],
                        zoom: 11.15
                    });

                    map.on('load', function () {
                        map.addSource('places', {
                            'type': 'geojson',
                            'data': {
                                'type': 'FeatureCollection',
                                'features': [
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Central Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1429763, 50.373002]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Crownhill Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1316598, 50.406669]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Devonport Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1748468,50.3721133]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Efford Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1092284, 50.3873895]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Estover Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1009854, 50.4106361]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>North Prospect Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1658357, 50.3919523]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Peverell Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1448845, 50.393474]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Plympton Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.0555331, 50.3900512]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Plymstock Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.0889189, 50.3600407]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>Southway Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [, -4.1261228, 50.4297958]
                                        }
                                    },
                                    {
                                        'type': 'Feature',
                                        'properties': {
                                            'description':
                                                '<strong>St Budeaux Library</strong><p>',
                                            'icon': 'library'
                                        },
                                        'geometry': {
                                            'type': 'Point',
                                            'coordinates': [-4.1867369, 50.4025162]
                                        }
                                    }
                                ]
                            }
                        });
                        // Add a layer showing the places.
                        map.addLayer({
                            'id': 'places',
                            'type': 'symbol',
                            'source': 'places',
                            'layout': {
                                'icon-image': '{icon}-15',
                                'icon-allow-overlap': true
                            }
                        });

                        // When a click event occurs on a feature in the places layer, open a popup at the
                        // location of the feature, with description HTML from its properties.
                        map.on('click', 'places', function (e) {
                            var coordinates = e.features[0].geometry.coordinates.slice();
                            var description = e.features[0].properties.description;

                        // Ensure that if the map is zoomed out such that multiple
                        // copies of the feature are visible, the popup appears
                        // over the copy being pointed to.
                            while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
                                coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
                            }

                            new mapboxgl.Popup()
                                .setLngLat(coordinates)
                                .setHTML(description)
                                .addTo(map);
                        });

                        // Change the cursor to a pointer when the mouse is over the places layer.
                        map.on('mouseenter', 'places', function () {
                            map.getCanvas().style.cursor = 'pointer';
                        });

                        // Change it back to a pointer when it leaves.
                        map.on('mouseleave', 'places', function () {
                            map.getCanvas().style.cursor = '';
                        });
                    });
                </script>
                </html>
            </div>
        </div>
    </div><br>

<?php
include_once 'footer.php';
?>