<?php
include_once 'header.php';
?>

    <link rel="stylesheet" href="../assets/css/styles.css">

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
    </style>

    <div class="container-fluid col-12">
        <div class="row">
            <div class="col-7">
                <table id="libraries">
                    <tbody>
                    <?php
                    if (($csvlibraryfile = fopen("../csv/libraries_information.csv", "r")) !== FALSE) {
                        while (($csvlibrarydata = fgetcsv($csvlibraryfile, 1000, ",")) !== FALSE) {
                            $error='';
                            $colcount = count($csvlibrarydata);
                            echo '<tr>';
                            if($colcount!=36) {
                                $error = 'Column count incorrect';
                            } else {
                                //check data types
                                if(!is_numeric($csvlibrarydata[0])) $error.='error';
                                $date = date_parse($csvlibrarydata[3]);
                                if (!($date["error_count"] == 0 && checkdate($date["month"], $date["day"], $date["year"]))) $error.='error';
                                if(!is_numeric($csvlibrarydata[6])) $error.='error';
                            }
                            switch($error) {
                                case "Column count incorrect":
                                    echo '<td></td>';
                                    echo '<td></td>';
                                    echo '<td class="error" >'.$error.'</td>';
                                    echo '<td></td>';
                                    echo '<td></td>';
                                    echo '<td></td>';
                                    echo '<td></td>';
                                    break;
                                case "error":
                                    echo '<td class="error">'.$csvlibrarydata[0].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[1].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[2].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[3].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[4].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[5].'</td>';
                                    echo '<td class="error">'.$csvlibrarydata[6].'</td>';
                                    break;
                                default:
                                    echo '<td>'.$csvlibrarydata[0].'</td>';
                                    echo '<td>'.$csvlibrarydata[1].'</td>';
                                    echo '<td>'.$csvlibrarydata[2].'</td>';
                                    echo '<td>'.$csvlibrarydata[3].'</td>';
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

<?php
include_once 'footer.php';
?>