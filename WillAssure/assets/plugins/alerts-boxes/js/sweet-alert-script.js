
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

     


    


     
     // roles
     $("#btnRoleformsubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#btnRoleformsubmitCHECK").click(function () {
         swal("Failed", "Data Already Exist", "error");
     });
     $("#btnRoleDataUpdate").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     //end
     

     // distributor
     $("#btnDistributorformsubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnDistributorformsubmitUPDATE").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });

     //end



     // users

     $("#btnUserformsubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#UpdatingUserformUPDATE").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     
     $("#btncheckuser").click(function () {
         swal("Failed", "Login Id Already Exists", "error");
     });
    // end


     //testator
     $("#ADDTestatorFormData").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#btnTestatorformsubmitUPDATE").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });



     //end

     // asset type

     $("#btnAssetformsubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#btnUpdateassettype").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });

     //end


     // asset category

     $("#btnassetcategoryadded").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnassetcategoryupdated").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });

     //end


     // acm
     
     $("#btnaddAssetSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });
     
     $("#btnassetcontrolUpdated").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     //end


     // btnassetinfo

     
     $("#btnassetinfosuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });
     
     $("#btnassetinfoupdate").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     //end



     // relation

     


     $("#btnMemberformsubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });




     $("#btnrelationupdate").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     
     $("#btnMemberformsubmitCHECK").click(function () {
         swal("Failed", "Data Already Exists", "error");
     });
     //end



     // beneficiary


     $("#btnBeneficiarySUCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     
     $("#btnBeneficiaryupdated").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     
     //end


     // alt benefi
     

     $("#btnalternatebenefisuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnupdatealternatesucess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     // nominee
     
     $("#btnnomineeinsertsuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnnomineeupdatesuccess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     // appointees
     
     $("#btnappointeeSuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#updatesuccessappointees").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end



     // alternate appointees
     
     $("#btnalternateappointeesSuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnaltappointesssucess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     //main asset 

     
     $("#btnmainassetsuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     //end


     // testator family
     
     $("#btntestatorfamilysubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#btntestatorUPDATESUCCESS").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });

     //end
 
     $("#btndeleteroles").click(function () {
               swal({
                    title: "Are you sure?",
                    text: "Once deleted you will not be able to recover!",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                  })
                  .then((willDelete) => {
                    if (willDelete) {
                      swal("Data has been deleted!", {
                        icon: "success",
                      });
                    } else {
                        swal("Data is safe!");
                    }
                  });
     });


     $("#btndistributorDelete").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
     });

     
     $("#btnuserformdelete").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
     });

    


     $("#btndeletetestator").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
     });
     

     $("#btntestatorfamilydelete").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
     });
     

     $("#btndeleteassettype").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
     });

    





     $("#btnassetcategorydeleted").click(function () {
         swal({
             title: "Are you sure?",
             text: "Once deleted you will not be able to recover!",
             icon: "warning",
             buttons: true,
             dangerMode: true,
         })
             .then((willDelete) => {
                 if (willDelete) {
                     swal("Data has been deleted!", {
                         icon: "success",
                     });
                 } else {
                     swal("Data is safe!");
                 }
             });
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
     

              // page linking notification
              $("#btnuserlink").click(function(){
                  swal("Information!", "Please Fill Out Company Form First...!", "info");
              });


            $("#testatorlinkcheck").click(function () {
                swal("Information!", "Please Fill Up Distributor Details First...!", "info");
            });


             $("#testatorfamilylinkcheck").click(function () {
                 swal("Information!", "Please Fill Out Testator Form First...!", "info");
             });

     

     $("#mainassetlinkcheck").click(function () {
         swal("Information!", "Please Fill Out Testator Form First...!", "info");
     });

     

     $("#Beneficiarylinkcheck").click(function () {
         swal("Information!", "Please Fill Testator and Assets Information First...!", "info");
     });

     

     $("#btnalternatebenefilinking").click(function () {
         swal("Information!", "Please Fill Beneficiary Form First...!", "info");
     });


     
     $("#btnnomineelinking").click(function () {
         swal("Information!", "Please Fill Out AssetInformation and Testator Form First...!", "info");
     });

     
     
     $("#btnalternateappointeesLinking").click(function () {
         swal("Information!", "Please Fill out Appointees Form First...!", "info");
     });
              //end



     // ROLE ASSIGNMENT
     

     $("#btnRoleAssignmentCHECK").click(function () {
         swal("Information!", "Please Fill out Appointees Form First...!", "info");
     });


     //END



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