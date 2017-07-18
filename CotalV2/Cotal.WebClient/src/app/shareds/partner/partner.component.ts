import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-partner',
  templateUrl: './partner.component.html',
  styleUrls: ['./partner.component.css']
})
export class PartnerComponent implements OnInit {

  constructor() { }

  ngOnInit() { 
  var owl = $('#partners');
    owl.owlCarousel({ 
      loop: true,
      margin: 10,
      autoplay: true,
      autoplayTimeout: 3000,
      autoplayHoverPause: true, 
    });
    $(function () {
      owl.trigger('play.owl.autoplay', [1000])
    })
  }

}
