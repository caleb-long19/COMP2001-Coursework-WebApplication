<?php
include_once 'header.php';
?>

    <!-- /. Container which contains the pages main header text to inform the user -->
    <main class="container">
        <! Provides some information for the user on the home page and provides a link to support them-->
        <div class="starter-template text-center py-5 px-3">
            <h1>Plymouth's Libraries: Location and Information</h1>
            <p class="lead">This website is used in order to present meaningful data representation on the<br>
                Plymouth Library Data Set</p>
            <a href="../public/support.php" class="link">Need Help? Click Here</a><br>
        </div>
    </main><!-- /.container -->

    <!-- /. Created a card class which provides information on the data set, it also contains a link to the original data set -->
    <div class="container-fluid col-9">
        <div class="row">
            <div class="col-12">
                <div class="row g-0 bg-light position-relative">
                    <div class="col-md-6 mb-md-0 p-md-4">
                        <img src="resources/plymlibrary.jpg" class="w-100" alt="...">
                    </div>
                    <div class="col-md-6 p-4 ps-md-0">
                        <h5 class="mt-0">The Plymouth Library Data Set - 2019</h5>
                        <p>This data set contains information on the locations of each library,
                            opening/closing times, Names, and locations. If you wish to view the data in a readable format,
                            please visit the Library Data Page. If you wish to visit the original data set, please select the link below!</p>
                        <a href="https://plymouth.thedata.place/dataset/librariesinformation/resource/c5ec0cb5-4b43-4566-abe9-0bcb5a0ffd46" class="stretched-link">Visit The Original Data Set</a><br>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br>

    <!-- /. Created a card class which provides information on the project vision, it also contains links to the Data page and the entity page -->
    <div class="container-fluid col-9">
        <div class="row">
            <div class="col-12">
                <div class="row g-0 bg-light position-relative">
                    <div class="col-md-6 mb-md-0 p-md-4">
                        <img src="resources/plymunilibrary.png" class="w-100" alt="...">
                    </div>
                    <div class="col-md-6 p-4 ps-md-0">
                        <h5 class="mt-0">Project Vision</h5>
                        <p>The vision for this project consists of creating a web based application which has the ability to display
                            data on Plymouth's Libraries e.g. Names, Addresses, Longitude/Latitude etc. The only difference is that this will be displayed in a human readable format.
                            This means that you can easily understand the data being represented to you. If you wish to see this data, please visit the Library Data Page</p>
                        <a href="data.php" class="link">Library Data</a><br>
                        <a href="http://web.socem.plymouth.ac.uk/COMP2001/clong/library/" class="link">View Linked Data</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

<?php
include_once 'footer.php';
?>