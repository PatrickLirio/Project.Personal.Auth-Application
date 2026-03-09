import { AfterViewInit, Component, ElementRef, signal, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from './features/auth/login/login';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Login],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements AfterViewInit {
  protected readonly title = signal('frontend');
  @ViewChild('gridContainer') gridContainer!: ElementRef;

  isPasswordVisible = false;
  statusText = 'System Ready';

  ngAfterViewInit() {
    this.createGrid();
    this.createShapes();
  }

  createGrid() {
    const container = this.gridContainer.nativeElement;

    for (let i = 0; i < 30; i++) {
      const line = document.createElement('div');
      line.className =
        'absolute w-full h-[1px] bg-gradient-to-r from-transparent via-cyan-400 to-transparent opacity-30 animate-pulse';
      line.style.top = i * 50 + 'px';
      line.style.animationDelay = i * 0.1 + 's';

      container.appendChild(line);
    }

    for (let i = 0; i < 40; i++) {
      const line = document.createElement('div');
      line.className =
        'absolute h-full w-[1px] bg-gradient-to-b from-transparent via-cyan-400 to-transparent opacity-30 animate-pulse';
      line.style.left = i * 50 + 'px';
      line.style.animationDelay = i * 0.1 + 0.5 + 's';

      container.appendChild(line);
    }
  }

  createShapes() {
    const container = this.gridContainer.nativeElement;

    const shapeCount = 8;

    for (let i = 0; i < shapeCount; i++) {
      const shape = document.createElement('div');

      const size = Math.random() * 200 + 100;

      shape.className = 'absolute border border-cyan-400/30 animate-spin';

      shape.style.width = size + 'px';
      shape.style.height = size + 'px';
      shape.style.left = Math.random() * 100 + '%';
      shape.style.top = Math.random() * 100 + '%';
      shape.style.animationDuration = Math.random() * 4 + 6 + 's';
      shape.style.animationDelay = i * 1.6 + 's';

      container.appendChild(shape);
    }
  }
}
