import {Component, OnInit, Input} from '@angular/core';
import {LocationService} from "../location.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})

export class LocationComponent implements OnInit {
  public locations: Array<any>;
  public incidents: Array<number>;

  public locationStatusMapping = ['Active', 'Inactive'];

  private locationService: LocationService;

  public locationForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(2)]),
      country: new FormControl('', [Validators.required, Validators.minLength(2)]),
      locationStatus: new FormControl('', [Validators.required]),
      latitude: new FormControl('', [Validators.required, Validators.min(-90), Validators.max(90)]),
      longitude: new FormControl('', [Validators.required, Validators.min(-180), Validators.max(180)]),
      proximitySize: new FormControl('', [Validators.required, Validators.min(1)]),
    }
  )

  constructor(private _locationService: LocationService) {
    this.locationService = _locationService;
    this.incidents = new Array<number>();
    this.fetchAllLocation();
  }

  private fetchAllLocation() {
    this.locationService.get().subscribe((data: any) => {
      this.locations = data;

      this.locations.forEach((location) => {
        this.locationService.getNumberOfIncident(location.id).subscribe((numberOfIncident: any) => {
          this.incidents[location.id] = numberOfIncident.numberOfResult;
        });
      })
    });
  }

  onSubmit() {
    if (this.locationForm.valid) {
      let postData = this.locationForm.value;
      postData.locationStatus = parseInt(postData.locationStatus);

      this.locationService.post(postData).subscribe((result: any) => this.fetchAllLocation());
    }
  }

  ngOnInit(): void {
  }

}
