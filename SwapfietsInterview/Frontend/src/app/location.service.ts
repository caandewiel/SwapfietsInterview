import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class LocationService {
  private headers: HttpHeaders;
  private url: string = 'https://localhost:5001/api/location/';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json'});
  }

  public get() {
    return this.http.get(this.url, { headers: this.headers });
  }

  public post(location) {
    return this.http.post(this.url, location, { headers: this.headers });
  }

  public getNumberOfIncident(id) {
    return this.http.get(this.url + id + '/incident', { headers: this.headers });
  }
}
