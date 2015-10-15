;;;; 2015-10-12 10:53:48
;;;;
;;;; Think of this as your project file.
;;;; Keep it up to date, and you can reload your project easily
;;;;  by right-clicking on it and selecting "Load Project"

(defpackage #:lab1lis-asd
  (:use :cl :asdf))

(in-package :lab1lis-asd)

(defsystem lab1lis
  :name "lab1lis"
  :version "0.1"
  :serial t
  :components ((:file "defpackage")
               (:file "main" :depends-on ("defpackage"))
               (:file "tests" :depends-on ("defpackage" "main"))
               
               ; As you add files to your project,
               ; make sure to add them here as well
               
               )
  :depends-on ())
