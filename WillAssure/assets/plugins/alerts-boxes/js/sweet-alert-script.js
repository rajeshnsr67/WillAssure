
 $(document).ready(function(){

              $("#alert-basic").click(function(){
                  swal("Hello world!");
              });

              $("#alert-title").click(function(){
                  swal("Here's the title!", "...and here's the text!");
              });

     //success Alert Button


              $("#btnOTPCheckSUCCESS").click(function(){
                  swal("Verified!", "Your OTP has Been Verified!,", "success");
              });
     

              $("#btnDeleteTestatorData").click(function () {
                 swal("Deleted!", "Your Data has Been Deleted!,", "success");
              });

     
                 $("#btnBeneficiarySUCESS").click(function () {
                     swal("Submitted!", "Your Data has Been Submitted!,", "success");
                 });


     $("#btnloginSUCCESS").click(function () {
         swal("Submitted!", "Your Data has Been Submitted!,", "success");
     });


     

     $("#btnRoleformsubmitSUCCESS").click(function () {
         swal("Roles Added!", "Your Data has Been Added!,", "success");
     });

     

     $(".btnRoleDeleteSUCCESS").click(function () {
         swal("Roles Deleted!", "Your Data has Been Deleted!,", "success");
     });

     


     $("#btnDistributorformsubmitSUCCESS").click(function () {
         swal("Distributor Added!", "Your Data has Been Added!,", "success");
     });

     

     $("#btnUserformsubmitSUCCESS").click(function () {
         swal("Records Added!", "Your Data has Been Added!,", "success");
     });

     
     $("#InsertTestatorFormDataSUCCESS").click(function () {
         swal("Testator Added!", "Your Data has Been Added!,", "success");
     });

     

     $("#btnAssetformsubmitSUCCESS").click(function () {
         swal("Asset Type Added!", "Your Data has Been Added!,", "success");
     });
     //end

     //Failed Alert Button

     $("#btnOTPCheckFAILED").click(function(){
                  swal("Failed!", "Please Enter Correct OTP!,", "error");
              });


     $("#btnloginFAILED").click(function () {
         swal("Failed!", "Please Enter Valid Details!,", "error");
     });

     //end

              $("#alert-info").click(function(){
                  swal("Information!", "You clicked the button!,", "info");
              });

              $("#alert-warning").click(function(){
                  swal("Warning!", "You clicked the button!,", "warning");
              });


              $("#confirm-btn-alert").click(function(){

                  swal({
                    title: "Are you sure?",
                    text: "Once deleted, you will not be able to recover this imaginary file!",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                  })
                  .then((willDelete) => {
                    if (willDelete) {
                      swal("Poof! Your imaginary file has been deleted!", {
                        icon: "success",
                      });
                    } else {
                      swal("Your imaginary file is safe!");
                    }
                  });

              });

          });