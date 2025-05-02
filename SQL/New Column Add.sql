ALTER TABLE TblMedicineDetails
ADD AllotedQuantity int NULL;

ALTER TABLE TblMedicineType
ADD QuantityAvailable int NULL;


UPDATE TblMedicineDetails 
set  AllotedQuantity  = 10


UPDATE TblMedicineType 
set  QuantityAvailable  = 300



UPDATE TblMenu
SET MenuName = 'MedicineDisease'
WHERE MenuID = 17;