<?php
header('Content-type: application/json');
//Reads library data csv (from plymouth datasets) into filename

$fileName = '../public/libraryData.csv';

if (($handle = fopen($fileName, 'r')) !== FALSE) {
    $string =
        '{
  "@context": [
    "https://schema.org",
    { "@language": "en-ca" }
  ],';
    //While row exists, keep looping
    while (($ArrayRow = fgetcsv($handle, 1000, ",")) !== FALSE) {
        $Tstring = '
            "@type": "Library",
             "name" : "' . ($ArrayRow[0]) .'",
             "address": {
                "postalCode" : "' . strval($ArrayRow[4]) . '"}';
                $string = $string . $Tstring;
            }
}
echo ($string);
?>



