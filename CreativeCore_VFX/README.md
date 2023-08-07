Also you can try to increase preempt timeout by editing 
/sys/class/drm/card0/engine/rcs0/preempt_timeout_ms 
file. Try to increase the state from default 640 to 10000.

echo 5000 | sudo tee /sys/class/drm/card0/engine/rcs0/preempt_timeout_ms

run blender with INTEL_DEBUG=reemit command line
