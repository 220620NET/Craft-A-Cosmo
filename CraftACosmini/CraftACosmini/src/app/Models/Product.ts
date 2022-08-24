export interface Product
{
    productId : number;
    catergoryIdFk : number;
    productOptionsIdFk : number;
    price : number;
    description : string;
    productName : string;
    productCol : string;
    productImage : Blob;
    listed : boolean;
}




