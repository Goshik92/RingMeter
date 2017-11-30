# Description
This OpenCV based program has been designed to measure the internal diameter of rings using a web camera. Before the measurement the system should be calibrated using a checkered picture.

# Demo video
[![RingMeter demo video](https://img.youtube.com/vi/RchOa2qP7Os/0.jpg)](https://www.youtube.com/watch?v=RchOa2qP7Os)

# Calibration
![alt tag](https://www.dropbox.com/s/rxm4tw31wtqhp97/calibration.png?raw=1)
Calibration is required for two purposes:
1. Finding relation between pixel measure and real world distance.
2. Compensation of camera distortion.

# Background correction
![alt tag](https://www.dropbox.com/s/f6wxdqlgsm2izpl/background-correction.png?raw=1)

# Measurement
![alt tag](https://www.dropbox.com/s/g1hfi8uz8xy912o/measurement.png?raw=1)
After internal ring contour recognition, it is approximated to a circle using the LMS method. The diameter of the circle is the measured value. 

# Keywords
OpenCV, opencvsharp, C#, image processing, camera calibration, ring measurement, обработка изображений, калибровка камеры, измерение диаметра кольца.
