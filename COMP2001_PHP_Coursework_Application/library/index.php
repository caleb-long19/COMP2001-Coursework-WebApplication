<?php
header('Content-type: application/json');

ini_set('auto_detect_line_endings', true);
$handle = fopen('../public/libraryData.csv', 'r');

echo "{\"@context\" : { \"Place\" : \"http://schema.org\"}, 
      \"Place\" : 
    [ ";

$cols = 0;
while(($data = fgetcsv($handle)) !== FALSE) {
    $rows = 0;
    if($cols != 0)
        foreach ($data as $key => $dataIndex){
            if($cols == 0){}

            //gets the library name value from column 1 in library data csv
            if ($rows == 0){$libraryName = "{\"@type\" : \"Library\", 
              \"name\" : \"" . $dataIndex . "\", \n ";
                echo $libraryName;
            }

            //Retrieves/Displays street address of library from 2nd column in the libraryData file
            else if ($rows == 1){$address = "\"address\" : \"streetAddress\", 
              \"Street Address\" : \"" . $dataIndex . "\", \n ";
                echo $address;
            }

            //Retrieves/Displays post code of library from 5nd column in the libraryData file
            else if ($rows == 4){$postalC = "\"address\" : \"PostalAddress\", 
              \"Post Code\" : \"" . $dataIndex . "\", \n ";
                echo $postalC;
            }

            //Retrieves/Displays latitude coords from 6th column in the libraryData file
            else if($rows == 5){$latitude = "\"geo\" : {\"@type\" : \"GeoCoordinates\", 
             \"latitude\" : " . $dataIndex. ", ";
                echo $latitude;
            }

            //Retrieves/Displays longitude coords from 7th column in the libraryData file
            else if($rows == 6){$longitude= "\"longitude\" : " . $dataIndex . "
                }}, \n ";
                if($dataIndex == '-4.1867369'){
                    $longitude= "\"longitude\" : " . $dataIndex . "
                }} \n ";
                    echo $longitude;
                }
                else
                {echo $longitude;}
            }
            $rows++;
        }
    $cols++;
}
echo "]}";

