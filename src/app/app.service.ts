import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders }    from '@angular/common/http';  

@Injectable({
  providedIn: 'root'
})
export class AppService {
  
  readonly rootURL = 'https://localhost:44394/api';

  constructor(private http: HttpClient) { }  
      httpOptions = {  
        headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
        })  
      }    
      getData(){  
        return this.http.get(this.rootURL + '/Clientes'); 
      }  
      
      // postData(formData){  
      //   return this.http.post(this.rootURL + '/Clientes',formData);  
      // }  
      
      // putData(id,formData){  
      //   return this.http.put(this.rootURL + '/Clientes/'+id,formData);  
      // }  
      // deleteData(id){  
      //   return this.http.delete(this.rootURL + '/Clientes/'+id);  
      // }  
}