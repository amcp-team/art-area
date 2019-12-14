import { Component, OnInit } from "@angular/core";
import { trigger, state, transition, style, animate } from '@angular/animations';
import * as AOS from 'aos';

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
  animations: [
    trigger('fade', [
       transition(':enter', [
         style({opacity: 0}),
         animate(2000)
       ])
    ]),

    trigger('fade1500',[
      transition(':enter', [
        style({opacity: 0}),
        animate(1500)
      ])
    ]),

    trigger('fade2500',[
      transition(':enter', [
        style({opacity: 0}),
        animate(2500)
      ])
    ]),

    trigger('fade3000',[
      transition(':enter', [
        style({opacity: 0}),
        animate(3000)
      ])
    ]),

    trigger('flyInOutLeft', [
      state('in', style({ transform: 'translateX(0)' })),
      transition(':enter', [
        style({ transform: 'translateX(-100%)' }),
        animate(1000)
      ]),
      transition(':leave', [
        animate(100, style({ transform: 'translateX(100%)' }))
      ])
    ]),

    trigger('flyInOutRight', [
      state('in', style({ transform: 'translateX(-100%)' })),
      transition(':enter', [
        style({ transform: 'translateX(100%)' }),
        animate(1000)
      ]),
      transition(':leave', [
        animate(5000, style({ transform: 'translateX(100%)' }))
      ])
    ])

  ]
})
export class HomeComponent implements OnInit {
  constructor() {}

  ngOnInit() {
    AOS.init();
  }

  scroll(el: HTMLElement){
    el.scrollIntoView({behavior: 'smooth'});
  }

  

  
}
