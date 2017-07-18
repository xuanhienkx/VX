import { Component, OnInit, AfterContentChecked } from '@angular/core';

@Component({
  selector: 'app-home-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit, AfterContentChecked {

  constructor() { }

  ngOnInit() {
    var owl = $('#owl-main-slider');
    owl.owlCarousel({
      items: 1,
      loop: true,
      margin: 10,
      autoplay: true,
      autoplayTimeout: 3000,
      autoplayHoverPause: true, 
    });
    $(function () {
      owl.trigger('play.owl.autoplay', [1000])
    })
    // $(document).ready(function () {
    //   //owl.trigger('play.owl.autoplay', [50])
    //   $('#owl-main-slider').owlCarousel({
    //     items: 1,
    //     loop: true,
    //     margin: 10,
    //     autoplay: true,
    //     autoplayTimeout: 100,
    //     autoplayHoverPause: true ,   
    //     autoHeight: false,
    //   });
    // });

  }
  ngAfterContentChecked() {

  }

}
