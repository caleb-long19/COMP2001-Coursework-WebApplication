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
        #libraries {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

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

        #map { height: 180px; }
    </style>
    <div class="container-fluid col-11">
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
                    if (($csvlibraryfile = fopen("../public/libraryData.csv", "r")) !== FALSE) {
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

        <div id="mapid"></div>
        <script>
            var mymap = L.map('mapid').setView([51.505, -0.09], 13);
            L.tileLayer('https://api.maptiler.com/maps/streets/tiles.json?key=4KHR0xIZCyeSYJf3TnlI', {
                attribution: '<a href="https://www.maptiler.com/copyright/" target="_blank">&copy; MapTiler</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">&copy; OpenStreetMap contributors</a>',{
            ).addTo(mymap);
            }
        </script>
    </div>

<?php
include_once 'footer.php';
?>