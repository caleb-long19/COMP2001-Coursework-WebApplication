<?

//Reads library data csv (from plymouth datasets) into filename
$fileName = "../public/libraryData.csv";

if (($handle = fopen($fileName, 'r')) !== FALSE) {
    $string =
        '{ "@context":{"Library": "http://schema.org/", "Libraries": "http://web.socem.plymouth.ac.uk"}, "Local Businesses", "Libraries":[
            ';
    //While row exists, keep looping
    while (($ArrayRow = fgetcsv($handle, 1000, ",")) !== FALSE) {
        $Tstring = '{
            "@type": "library",
                        "name" : "' . ($ArrayRow[0]) .'",
                        "address" : "' . strval($ArrayRow[1]) .'",
                        "postalCode" : "' . strval($ArrayRow[4]) . '",
                        "geo": "{
                            "@type" : "GeoCoordinates",
                            "latitude" : "' . strval($ArrayRow[5]) . '",
                            "longitude" : "' . strval($ArrayRow[6]) . '"
                         },
                         "openingHoursSpecification": [
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[7]) .'",
                                  "dayOfWeek" : "https://schema.org/Monday",
                                  "opens" :  "' . strval($ArrayRow[8]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[9]) .'" ,
                                  "dayOfWeek" : "https://schema.org/Tuesday",
                                  "opens" : "' . strval($ArrayRow[10]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" :  "' . strval($ArrayRow[11]) .'",
                                  "dayOfWeek" : "https://schema.org/Wednesday",
                                  "opens" : "' . strval($ArrayRow[12]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[13]) .'",
                                  "dayOfWeek" : "https://schema.org/Thursday",
                                  "opens" : "' . strval($ArrayRow[14]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[15]) .'",
                                  "dayOfWeek" :  "https://schema.org/Friday",
                                  "opens" : "' . strval($ArrayRow[16]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[17]) .'",
                                  "dayOfWeek" : "https://schema.org/Saturday",
                                  "opens" : "' . strval($ArrayRow[18]) .'"
                                },
                                {
                                  "@type" : "OpeningHoursSpecification",
                                  "closes" : "' . strval($ArrayRow[19]) .'",
                                  "dayOfWeek" :  "https://schema.org/Sunday",
                                }
                                 "url" : "' . ($ArrayRow[35]) . '"},
                              ]
                ';
                $string = $string . $Tstring;
            }
}
header('Content-type: application/json');
echo print_r($string);
fclose($handle);



